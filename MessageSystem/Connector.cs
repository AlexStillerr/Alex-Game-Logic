using System;
using System.Collections.Generic;
using System.Threading;

/*
 * The Connector is the central component of the message system.
 * 
 * It maintains a dictionary that maps a message type (e.g. IAction or IHook)
 * to a list of delegates (listeners) associated with that type.
 * 
 * When a message is triggered, the Connector looks up all delegates for the
 * given type and invokes them, passing the message as a parameter.
 */

namespace AGL.MessageSystem
{
    public class Connector<R> : IMessageDispatcher<R>
    {
        // call one action after another
        private SemaphoreSlim isBlocked = new SemaphoreSlim(1, 1);
        private Dictionary<Type, List<Delegate>> typeDelegateMapping = new();

        public void AddListener<T>(Listener<T> l) where T : R
        {
            var t = typeof(T);
            if (!typeDelegateMapping.TryGetValue(t, out List<Delegate> _))
                typeDelegateMapping.Add(t, new());

            if (typeDelegateMapping[t].Contains(l))
                UnityEngine.Debug.LogError($"{t} is registered");
            else
                typeDelegateMapping[t].Add(l);
        }

        public void Clear()
        {
            typeDelegateMapping.Clear();
        }

        public async void Execute<T>(T message) where T : R
        {
            var t = message.GetType();

            // Handling a message may trigger another message.
            // To preserve the correct execution order, it is important to wait until the current message has been fully processed.
            await isBlocked.WaitAsync();

            try
            {
                if (typeDelegateMapping.TryGetValue(t, out List<Delegate> list))
                {
                    List<Delegate> executeList = new(list);
                    foreach (Delegate d in executeList)
                    {
                        (d as Listener<T>).Invoke(message);
                    }
                }
            }
            finally { isBlocked.Release(); }
        }

        public void RemoveListener<T>(Listener<T> l) where T : R
        {
            var t = typeof(T);
            Remove(t, l);
        }

        private void Remove(Type t, Delegate l)
        {
            if (typeDelegateMapping.TryGetValue(t, out List<Delegate> list))
            {
                list.Remove(l);
                if (list.Count == 0)
                    typeDelegateMapping.Remove(t);
            }
        }

        public void RemoveConnector(IMessageDispatcher<R> other)
        {
            var listeners = (other as Connector<R>).typeDelegateMapping;
            foreach (var pair in listeners)
            {
                foreach (var t in pair.Value)
                    Remove(pair.Key, t);
            }
        }

        public int CountConnections()
        {
            int count = 0;
            foreach(var pair in typeDelegateMapping)
            {
                count += pair.Value.Count;
            }

            return count;
        }
    }
}

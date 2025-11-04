/*
 * A Subscriber manages a scoped set of listeners within the Message System.
 * 
 * It is created by the IMessageBus and registers listeners both in its own local collection
 * and in the parent (global) collection. This allows for grouped listener management,
 * enabling partial unsubscription or targeted cleanup.
*/

namespace AGL.MessageSystem
{
    public class Subscriber<R> : ISubscribe<R>
    {
        private IMessageDispatcher<R> parentCollection;
        private Connector<R> ownCollection;

        public Subscriber(IMessageDispatcher<R> connector)
        {
            parentCollection = connector;
            ownCollection = new();
        }

        public Subscriber<R> Add<T>(Listener<T> listener) where T : R
        {
            parentCollection.AddListener(listener);
            ownCollection.AddListener(listener);

            return this;
        }

        public Subscriber<R> Remove<T>(Listener<T> listener) where T : R
        {
            parentCollection.RemoveListener(listener);
            ownCollection.RemoveListener(listener);

            return this;
        }

        public void Reset()
        {
            parentCollection.RemoveConnector(ownCollection);
            ownCollection.Clear();
        }
    }
}

/*
 * Interface for the Connectors
*/

namespace AGL.MessageSystem
{
    public interface IMessageDispatcher<R>
    {
        void AddListener<T>(Listener<T> l) where T : R;
        void RemoveListener<T>(Listener<T> l) where T : R;
        void RemoveConnector(IMessageDispatcher<R> other);
        void Execute<T>(T message) where T : R;
        void Clear();
        int CountConnections();
    }
}

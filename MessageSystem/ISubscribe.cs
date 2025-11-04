/*
 * Interface of the Subscriber to add and remove Listeners
*/

namespace AGL.MessageSystem
{
    public delegate void Listener<in T>(T message);

    public interface ISubscribe<R>
    {
        Subscriber<R> Add<T>(Listener<T> listener) where T : R;
        Subscriber<R> Remove<T>(Listener<T> listener) where T : R;
        void Reset();
    }
}

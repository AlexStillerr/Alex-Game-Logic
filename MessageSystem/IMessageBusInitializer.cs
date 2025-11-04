/*
 * Helper interface for initialization of the message system
 */

namespace AGL.MessageSystem
{
    public interface IMessageBusInitializer
    {
        void Init(IMessageBus bus);
    }
}

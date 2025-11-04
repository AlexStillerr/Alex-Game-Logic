using UnityEngine;

/*
 * A ScriptableObject that holds a reference to the MessageHandler.
 * 
 * Can be used to provide the IMessageBus to components that do not implement
 * the IMessageBusInitializer interface — for example, components created at runtime.
 */

namespace AGL.MessageSystem
{
    [CreateAssetMenu(fileName = "MessageBus", menuName = "AlexGameLogic/MessageBus", order = 0)]
    public class MessageBusObj : ScriptableObject
    {
        public IMessageBus MessageBus { get; } = MessageHandler.CreateMessageHandler();
    }
}
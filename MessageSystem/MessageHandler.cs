/*
 * MessageHandler is the concrete implementation of the IMessageBus interface.
 * 
 * There should only be a single instance of this handler.
 * It holds the main connectors for actions and hooks, where all listeners are registered.
 * 
 * It is also responsible for creating Subscribers that are linked to these main connectors.
 */

namespace AGL.MessageSystem
{
    public class MessageHandler : IMessageBus
    {
        private class HookConnector : Connector<IHook> { }
        private class ActionConnector : Connector<IAction> { }

        private HookConnector hookConnector = new();
        private ActionConnector actionConnector = new();

        private static MessageHandler instance;

        private MessageHandler() { }

        public static MessageHandler CreateMessageHandler()
        {
            if (instance == null)
                instance = new MessageHandler();
            else
                UnityEngine.Debug.LogWarning("Messagebus allready created");

            return instance;
        }

        public ActionSubscriber CreateActionSubscriber()
        {
            return new ActionSubscriber(actionConnector);
        }

        public HookSubscriber CreateHookSubscriber()
        {
            return new HookSubscriber(hookConnector);
        }

        public void TriggerAction<T>(T action) where T : IAction
        {
            actionConnector.Execute(action);
        }       

        public void TriggerHook<T>(T hook) where T : IHook
        {
            hookConnector.Execute(hook);
        }
    }
}

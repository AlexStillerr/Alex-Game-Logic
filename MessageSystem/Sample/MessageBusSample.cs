using UnityEngine;

/*
 * A sample to show how to use the Message system.
*/

namespace AGL.MessageSystem.Sample
{
    // Create a test Action
    internal class MessageBusSampleAction : IAction
    {
        public string Text { get; private set; }
        public MessageBusSampleAction(string text)
        {
            Text = text;
        }
    }

    // and a test Hook
    internal class MessageBusSampleHook : IHook
    { }

    internal class MessageBusSample : MonoBehaviour
    {
        private IMessageBus messageBus;

        private ActionSubscriber actionSubscriber;
        private HookSubscriber hookSubscriber;

        void Start()
        {
            // create the message handler
            messageBus = MessageHandler.CreateMessageHandler();

            // and get own Subscriber for this Class
            actionSubscriber = messageBus.CreateActionSubscriber();
            hookSubscriber = messageBus.CreateHookSubscriber();

            // Register a function to an action/hook Class.
            // This function will be called after a action/hook will be send to the Message system
            actionSubscriber.Add<MessageBusSampleAction>(ReceiveAction);
            hookSubscriber.Add<MessageBusSampleHook>(ReceiveHook);
        }

        private void OnDisable()
        {
            // Unregister all functions and cancel the Class to function mapping
            actionSubscriber?.Reset();
            hookSubscriber?.Reset();
        }

        void Update()
        {
            // trigger the Message system by sending a action/hook class
            if (Input.GetKeyUp(KeyCode.A))
                messageBus.TriggerAction(new MessageBusSampleAction("Action test"));
            if (Input.GetKeyUp(KeyCode.H))
                messageBus.TriggerHook(new MessageBusSampleHook());
        }

        private void ReceiveHook(MessageBusSampleHook message)
        {
            Debug.Log("Trigger Hook");
        }

        private void ReceiveAction(MessageBusSampleAction message)
        {
            Debug.Log($"Trigger Action with text -> {message.Text}");
        }
    }
}
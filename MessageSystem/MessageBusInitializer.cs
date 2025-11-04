using System.Linq;
using UnityEngine;

/*
 * Initializes the Message System in Unity.
 * 
 * It either uses a MessageHandler provided via ScriptableObject or creates a new one.
 * Then, it searches for all classes implementing the IMessageBusInitializer interface
 * and passes the IMessageBus instance to them.
 * 
 * InitializeMessageBus|InitializeMessageBusForced need to be called from the outside
 */

namespace AGL.MessageSystem
{
    public class MessageBusInitializer : MonoBehaviour
    {
        [SerializeField]
        private MessageBusObj messageBusObj;
        
        public IMessageBus Bus { get; private set; }
        
        public void InitializeMessageBusForced()
        {
            SetupMessageBus();

            InitializeDependencies(true);
        }

        public void InitializeMessageBus()
        {
            bool initialisationNeeded = SetupMessageBus(); 

            InitializeDependencies(initialisationNeeded);
        }

        private bool SetupMessageBus()
        {
            if (Bus == null)
            {
                if (messageBusObj == null)
                {
                    Debug.LogWarning("messageBusObj == null -> Create new MessageHandler");
                    Bus = MessageHandler.CreateMessageHandler();
                }
                else
                    Bus = messageBusObj.MessageBus;

                return true;
            }
            return false;
        }

        private void InitializeDependencies(bool shouldRunInit)
        {
            if (shouldRunInit)
            {
                var otherScripts = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IMessageBusInitializer>();
                foreach (IMessageBusInitializer script in otherScripts)
                    script.Init(Bus);
            }
        }
        
    }
}
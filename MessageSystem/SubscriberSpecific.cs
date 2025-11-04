namespace AGL.MessageSystem
{
    // Specific Subscriber type for IHook's
    public class HookSubscriber : Subscriber<IHook>
    {
        public HookSubscriber(IMessageDispatcher<IHook> connector) : base(connector)
        {
        }
    }

    // Specific Subscriber type for IAction's
    public class ActionSubscriber : Subscriber<IAction>
    {
        public ActionSubscriber(IMessageDispatcher<IAction> connector) : base(connector)
        {
        }
    }

}

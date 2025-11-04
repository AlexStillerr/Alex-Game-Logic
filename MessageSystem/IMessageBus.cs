/*
 * Primary interface for message handling.
 * All other components interact with the message system exclusively through this interface.
 */

namespace AGL.MessageSystem
{
    public interface IMessageBus
    {
        void TriggerHook<T>(T hook) where T : IHook;
        HookSubscriber CreateHookSubscriber();

        void TriggerAction<T>(T hook) where T : IAction;
        ActionSubscriber CreateActionSubscriber();
    }

    public interface IAction { } // to game
    public interface IHook { } // to ui
    public interface IServer { } // to network or server -> Not Implemented
}

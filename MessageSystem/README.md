The Message System is a modular and decoupled communication framework designed for Unity. It allows components to interact through messages without requiring direct references to one another, using a publish-subscribe pattern based on type-safe message interfaces.

At the core of the system is the MessageHandler, a singleton that implements the IMessageBus interface. It holds two container classes (called Connector) — one for IAction messages and one for IHook messages — each managing type-based lists of delegates (listeners). These connectors are responsible for executing registered listeners when a corresponding message is triggered.

To support localized message management, the system introduces the concept of Subscribers. A Subscriber<T> registers listeners in both the global connector(inside MessageHandler) and its own scoped connector. This allows grouped registration and removal of listeners, giving finer control over subsets of the message system—ideal for lifecycle-bound components.

The system supports flexible initialization:
Components that implement IMessageBusInitializer receive the IMessageBus during setup, while others (e.g. runtime-created objects) can access it via the ScriptableObject.

This architecture makes the system extensible, testable, and easy to integrate into complex Unity applications.

It used to different semantic types of messages IAction for GameLogic stuff and IHook for UI related

How to implement:
Setup:
1. Copy Package to your project
2. Add MessageBusInitializer to your scene
2a. (otional) create MessageBusObj and assign to MessageBusInitializer.
3. run InitializeMessageBus from MessageBusInitializer.

Use Action (Hooks work the same way but need the IHook interface):
4. create a MonoBehaviour script for MessageBus usage and add the IMessageBusInitializer interface to it -> class Sample : MonoBehaviour, IMessageBusInitializer
5. Get Subscriber from MessageBus -> actionSubscriber = messageBus.CreateActionSubscriber();
6. create a class with IAction interface -> class Bubu : IAction
7. Register class to the messageBus -> actionSubscriber.Add<Bubu>(IsCalled);
8. Create registered function -> void IsCalled(Bubu message)
9. Call action from somewhere -> bus.TriggerAction(new Bubu());

If no longer Needed do your Cleanup
10. Eigher actionSubscriber.Remove<Bubu>(IsCalled)
11. or actionSubscriber.Reset();
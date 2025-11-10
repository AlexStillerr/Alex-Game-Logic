using AGL.MessageSystem;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AGL.CameraController
{
    internal class DungeonCamera : MonoBehaviour, IMessageBusInitializer
    {
        [SerializeField]
        private Tilemap walkMap;
        [SerializeField]
        private Transform player;

        private ActionSubscriber actionSubscriber;
        private IMessageBus messageBus;

        public void Init(IMessageBus bus)
        {
            messageBus = bus;
            actionSubscriber = messageBus.CreateActionSubscriber();
            actionSubscriber.Add<MessageSystemInitializedAction>(AfterSetup);
        }

        private void AfterSetup(MessageSystemInitializedAction message)
        {
            messageBus.TriggerHook(new SetWalkableTilemapHook(walkMap));
            messageBus.TriggerHook(new SetTargetToFollowHook(player));
        }
    }
}

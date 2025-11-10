using UnityEngine.Tilemaps;
using UnityEngine;
using AGL.MessageSystem;
using System;

namespace AGL.CameraController
{
    public class CameraControllerFollowUnit : MonoBehaviour, IMessageBusInitializer
    {
        private Transform target;
        private Tilemap tilemap;

        private float xMax, xMin, yMax, yMin;

        [SerializeField]
        private Vector3 borderOffset;
        [SerializeField]
        private float offsetForUI = 0;

        HookSubscriber hookSubscriber;

        public void Init(IMessageBus bus)
        {
            hookSubscriber = bus.CreateHookSubscriber();
            hookSubscriber.Add<SetTargetToFollowHook>(SetFollowTarget)
                .Add<SetWalkableTilemapHook>(SetupTilemap);
        }

        private void OnDestroy()
        {
            hookSubscriber?.Reset();
        }

        private void SetupTilemap(SetWalkableTilemapHook message)
        {
            tilemap = message.Terrain;
            Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
            Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

            SetLimitsOrthogonal(minTile, maxTile);
        }

        private void SetFollowTarget(SetTargetToFollowHook message)
        {
            target = message.Target;
        }


        /// <summary>
        /// Call after all "normal" updates are done and move the target back on the visible area
        /// </summary>
        private void LateUpdate()
        {
            if (target != null)
            {
                Camera.main.transform.position = CreateClampedPosition(target.position);
            }
        }

        private Vector3 CreateClampedPosition(Vector3 position)
        {
            return new(Mathf.Clamp(position.x, xMin, xMax),
                       Mathf.Clamp(position.y + offsetForUI, yMin, yMax),
                       Camera.main.transform.position.z);
        }

        private void SetLimitsOrthogonal(Vector3 minTile, Vector3 maxTile)
        {
            Camera cam = Camera.main;

            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            xMin = minTile.x + width / 2 - borderOffset.x;
            xMax = maxTile.x - width / 2;

            yMin = minTile.y + height / 2 - borderOffset.y;
            yMax = maxTile.y - height / 2 + offsetForUI;
        }
    }
}

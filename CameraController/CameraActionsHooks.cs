using AGL.MessageSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AGL.CameraController
{
    public class SetTargetToFollowHook : IHook
    {
        public Transform Target { get; private set; }
        public SetTargetToFollowHook(Transform target) 
        { 
            Target = target;
        }
    }

    public class SetWalkableTilemapHook : IHook
    {
        public Tilemap Terrain { get; private set; }
        public SetWalkableTilemapHook(Tilemap terrain)
        {
            Terrain = terrain;
        }
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

namespace AGL.Player
{
    internal class MoveRangeTilemap : IHandleMoveRange
    {
        private Bounds mapBounds;

        public MoveRangeTilemap(Tilemap map, Vector2 size)
        {
            mapBounds = new Bounds(map.localBounds.center, map.localBounds.size - new Vector3(size.x, size.y, 0));
        }

        public bool CanWalk(Vector2 position)
        {
            return mapBounds.Contains(position);
        }
    }
}

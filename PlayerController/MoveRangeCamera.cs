using UnityEngine;

namespace AGL.Player
{
    internal class MoveRangeCamera : IHandleMoveRange
    {
        private Rect border;

        public Vector3 ClampToBorder(Vector3 origin)
        {
            origin.x = Mathf.Clamp(origin.x, border.x, border.x + border.width);
            origin.y = Mathf.Clamp(origin.y, border.y, border.y + border.height);
            return origin;
        }

        public bool CanWalk(Vector2 position)
        {
            //Debug.Log($"{position} -- {border}");
            return border.Contains(position);
        }

        public MoveRangeCamera(Vector2 playerSize)
        {
            Camera camera = Camera.main;
            Vector2 halfsize = playerSize * 0.5f;

            float camHeight = camera.orthographicSize * 2f;
            float camWidth = camHeight * camera.aspect;

            border = new Rect(camera.transform.position.x - camWidth/2 + halfsize.x,
                        camera.transform.position.y - camHeight/2 + halfsize.y,
                        camWidth - halfsize.x,
                        camHeight - halfsize.y);
        }
    }
}

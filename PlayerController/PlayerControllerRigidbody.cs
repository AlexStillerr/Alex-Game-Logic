using UnityEngine;
using UnityEngine.Tilemaps;

namespace AGL.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class PlayerControllerRigidbody : PlayerController
    {
        [SerializeField]
        private Tilemap moveGround;

        private Rigidbody2D rb;

        protected override void InitializeMovement()
        {
            movementHandler = new MovementHandlerRigidbody(new MoveWithKeyboard());
            movementHandler.SetupHandler(gameObject, stats);

            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
    }
}

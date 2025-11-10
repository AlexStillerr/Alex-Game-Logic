using AGL.MessageSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AGL.Player
{
    internal class PlayerControllerDungeon : PlayerController
    {
        [SerializeField]
        private Tilemap moveGround;

        protected override void InitializeMovement()
        {
            Vector2 playerSize = new(1, 1);
            movementHandler = new MovementHandler(new MoveWithKeyboard(), new MoveRangeTilemap(moveGround, playerSize));
            movementHandler.SetupHandler(gameObject, stats);
        }
    }
}

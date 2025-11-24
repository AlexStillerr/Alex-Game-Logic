using UnityEngine;

namespace AGL.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        protected Transform startPosition;
        [SerializeField]
        protected MovementStats stats;

        protected MovementHandlerBase movementHandler;

        void Start()
        {
            InitializePlayer();
            InitializeMovement();
        }

        protected virtual void InitializeMovement()
        {
            Vector2 playerSize = new Vector2(1, 1);
            movementHandler = new MovementHandlerTilemap(new MoveWithKeyboard(), new MoveRangeCamera(playerSize));
            movementHandler.SetupHandler(gameObject, stats);
        }

        public void InitializePlayer()
        {
            if(startPosition != null) 
                transform.position = startPosition.position;
        }

        void Update()
        {
            movementHandler.UpdateMovement();            
        }

        void FixedUpdate()
        {
            movementHandler.Move();
        }

    }
}
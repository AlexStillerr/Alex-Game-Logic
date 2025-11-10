using UnityEngine;

namespace AGL.Player
{
    public interface IReceiveMoveInput
    {
        Vector2 GetMoveVector();
    }

    public class MoveWithKeyboard : IReceiveMoveInput
    {
        private Vector2 moveInput;
        public Vector2 GetMoveVector()
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            
            return moveInput.normalized;
        }

        public Vector2 GetMoveVectorOld()
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveInput += Vector2.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveInput += Vector2.right;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                moveInput += Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                moveInput += Vector2.down;
            }
            return moveInput.normalized;
        }
    }
}

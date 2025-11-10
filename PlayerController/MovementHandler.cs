using System;
using UnityEditor;
using UnityEngine;

namespace AGL.Player
{
    public interface IHandlePlayerMovement
    {
        void UpdateMovement();
        void Move();
    }

    public interface IHandleMoveRange
    {
        bool CanWalk(Vector2 position);
        //Vector3 ClampToBorder(Vector3 origin);
    }

    public class MovementHandler
    {
        private SpriteRenderer render;
        private Transform target;
        private Rigidbody2D rb;
        private Vector2 movement;

        private MovementStats stats;

        IReceiveMoveInput input;
        IHandleMoveRange moveRange;

        public MovementHandler(IReceiveMoveInput input, IHandleMoveRange moveRange)
        {
            this.input = input;
            this.moveRange = moveRange;
        }

        public void SetupHandler(GameObject player, MovementStats stats)
        {
            this.stats = stats;
            target = player.transform;
            render = player.GetComponentInChildren<SpriteRenderer>();
            //rb = player.GetComponent<Rigidbody2D>();
            //rb.gravityScale = 0;
        }

        public void UpdateMovement()
        {
            movement = input.GetMoveVector();
            
            if (stats.UseRotation && movement != Vector2.zero)
            {
                float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                render.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        /*
        public void Move()
        {
            if( moveRange.CanWalk(rb.position+ movement * stats.MoveSpeed))
                rb.linearVelocity = movement * stats.MoveSpeed;
            else
                rb.position =  moveRange.ClampToBorder(rb.position);
                
        }
        /*/ 
        //Without Rigidbody
        public void Move()
        {
            Vector3 pos = target.position;
            pos.x += (Time.deltaTime * stats.MoveSpeed * movement.x);
            pos.y += (Time.deltaTime * stats.MoveSpeed * movement.y);
            
            if(moveRange.CanWalk(pos))
                target.position = pos;
        }
        //*/
    }
}

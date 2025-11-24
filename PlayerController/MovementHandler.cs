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

    public abstract class MovementHandlerBase
    {
        protected Transform target;
        protected Vector2 movement;

        protected MovementStats stats;

        protected IReceiveMoveInput input;

        public MovementHandlerBase(IReceiveMoveInput input)
        {
            this.input = input;
        }

        public virtual void SetupHandler(GameObject player, MovementStats stats)
        {
            this.stats = stats;
            target = player.transform;
        }

        public void UpdateMovement()
        {
            movement = input.GetMoveVector();
        }

        public abstract void Move();
    }

    public class MovementHandlerTilemap : MovementHandlerBase
    {
        private SpriteRenderer render;

        protected IHandleMoveRange moveRange;

        public MovementHandlerTilemap(IReceiveMoveInput input, IHandleMoveRange moveRange) : base(input)
        {
            this.moveRange = moveRange;
        }

        public override void SetupHandler(GameObject player, MovementStats stats)
        {
            base.SetupHandler(player, stats);
            render = player.GetComponentInChildren<SpriteRenderer>();
        }

        public override void Move()
        {
            Vector3 pos = target.position;
            pos.x += (Time.deltaTime * stats.MoveSpeed * movement.x);
            pos.y += (Time.deltaTime * stats.MoveSpeed * movement.y);
            
            if(moveRange.CanWalk(pos))
                target.position = pos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AGL.Player
{
    public class MovementHandlerRigidbody : MovementHandlerBase
    {
        private Rigidbody2D rb;

        public MovementHandlerRigidbody(IReceiveMoveInput input) : base(input)
        {
        }

        public override void SetupHandler(GameObject player, MovementStats stats)
        {
            base.SetupHandler(player, stats);

            rb = player.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
        
        public override void Move()
        {
            rb.linearVelocity = movement * stats.MoveSpeed;
        }
    }
}

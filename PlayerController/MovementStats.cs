using System;
using UnityEngine;

namespace AGL.Player
{
    [Serializable]
    public class MovementStats
    {
        [SerializeField]
        private float MinMoveSpeed = 3, MaxMoveSpeed = 10, moveSpeed = 5f;
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = Math.Clamp(value, MinMoveSpeed, MaxMoveSpeed); }

        [SerializeField]
        private bool useRotation;
        public bool UseRotation => useRotation;
    }
}

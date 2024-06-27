using System;
using UnityEngine;

namespace Gameplay.Player.Info
{
    [Serializable]
    public class JumpLogicInfo
    {
        public int MaxJumpCount => maxJumpCount;
        public float JumpForce => jumpForce;
        
        [SerializeField] private int maxJumpCount;
        [SerializeField] private float jumpForce;
    }
}
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInfo: MonoBehaviour
    {
        public bool IsGrounded => playerLogic.IsGrounded();
        
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;

        public Rigidbody Rigidbody => rigidbody;
        
        public int MaxJumpCount => maxJumpCount;

        public LayerMask GroundLayer => groundLayer;

        public float GroundCheckDistance => groundCheckDistance;

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private int maxJumpCount = 2;
        [SerializeField] private PlayerLogic playerLogic;
        [SerializeField] private float groundCheckDistance = 1.1f;
        [SerializeField] private LayerMask groundLayer;
    }
}
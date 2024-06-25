using Sirenix.Utilities;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInfo: MonoBehaviour
    {
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
        public Rigidbody Rigidbody => rigidbody;
        public int MaxJumpCount => maxJumpCount;
        public AnimatorController Animator => animator;

        [Header("Global")]
        [SerializeField] private PlayerLogic playerLogic;
        [SerializeField] private AnimatorController animator;
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 5f;
        [Header("Jump Settings")]
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private int maxJumpCount = 2;
        
    }
}
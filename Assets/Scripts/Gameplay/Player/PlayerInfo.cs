using Gameplay.Player.SubPakage;
using Sirenix.Utilities;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInfo: MonoBehaviour
    {
        public float MoveSpeed => moveSpeed;
        public Rigidbody Rigidbody => rigidbody;
        public AnimatorController Animator => animator;
        public JumpLogicInfo JumpLogicInfo => jumpLogicInfo;

        [Header("Global")]
        [SerializeField] private PlayerLogic playerLogic;
        [SerializeField] private AnimatorController animator;
        [SerializeField] private new Rigidbody rigidbody;
        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed = 5f;

        [Header("Jump Settings")] 
        [SerializeField] private JumpLogicInfo jumpLogicInfo;
    }
}
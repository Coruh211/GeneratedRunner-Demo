using Gameplay.Player.Info;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInfo: MonoBehaviour
    {
        public Rigidbody Rigidbody => rigidbody;
        public AnimatorController Animator => animator;
        public JumpLogicInfo JumpLogicInfo => jumpLogicInfo;
        public HpLogicInfo HpLogicInfo => hpLogicInfo;
        public MovementInfo MovementInfo => movementInfo;

        [Header("Global")]
        [SerializeField] private PlayerLogic playerLogic;
        [SerializeField] private AnimatorController animator;
        [SerializeField] private new Rigidbody rigidbody;
        [Header("Movement Settings")]
        [SerializeField] private MovementInfo movementInfo;
        [Header("Jump Settings")] 
        [SerializeField] private JumpLogicInfo jumpLogicInfo;
        [Header("Hp Settings")] 
        [SerializeField] private HpLogicInfo hpLogicInfo;
    }
}
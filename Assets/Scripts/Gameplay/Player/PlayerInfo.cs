using System.Net.NetworkInformation;
using Gameplay.Player.SubPakage;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player
{
    public class PlayerInfo: MonoBehaviour
    {
        public float DefaultMoveSpeed => defaultMoveSpeed;
        public Rigidbody Rigidbody => rigidbody;
        public AnimatorController Animator => animator;
        public JumpLogicInfo JumpLogicInfo => jumpLogicInfo;
        public int MaxHp => maxHp;
        public ParticleSystem RemoveHpParticle => removeHpParticle;

        [Header("Global")]
        [SerializeField] private PlayerLogic playerLogic;
        [SerializeField] private AnimatorController animator;
        [SerializeField] private new Rigidbody rigidbody;
        [Header("Movement Settings")]
        [SerializeField] private float defaultMoveSpeed = 5f;
        [Header("Jump Settings")] 
        [SerializeField] private JumpLogicInfo jumpLogicInfo;
        [Header("Hp Settings")]
        [SerializeField] private int maxHp = 3;
        [SerializeField] private ParticleSystem removeHpParticle;
    }
    
}
using System;
using UnityEngine;

namespace Gameplay.Player.Info
{
    [Serializable]
    public class MovementInfo
    {
        public float DefaultMoveSpeed => defaultMoveSpeed;
        public float ReviveMoveSpeed => reviveMoveSpeed;
        public float ReviveSpeedChangeTime => reviveSpeedChangeTime;
        
        [SerializeField] private float defaultMoveSpeed = 5f;
        [SerializeField] private float reviveMoveSpeed = 2.5f;
        [SerializeField] private float reviveSpeedChangeTime = 2f;
    }
}
using System;
using TMPro;
using UnityEngine;

namespace Gameplay.Player.SubPakage
{
    [Serializable]
    public class HpLogicInfo
    {
        public int MaxHp => maxHp;
        public ParticleSystem RemoveHpParticle => removeHpParticle;
        public TextMeshProUGUI HpText => hpText;
        
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private int maxHp = 3;
        [SerializeField] private ParticleSystem removeHpParticle;
    }
}
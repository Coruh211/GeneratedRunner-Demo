using UnityEngine;

namespace Gameplay.BonusLogic.SubClasses
{
    public class SpeedUpBonus : Bonus
    {
        public float NewSpeed => newSpeed;
        public float ActiveTime => activeTime;

        [SerializeField] private float newSpeed;
        [SerializeField] private float activeTime;
    }
}
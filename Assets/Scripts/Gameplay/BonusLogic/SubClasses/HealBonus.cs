using UnityEngine;

namespace Gameplay.BonusLogic.SubClasses
{
    public class HealBonus : Bonus
    {
        public int HealValue => healValue;
        
        [SerializeField] private int healValue;
    }
}
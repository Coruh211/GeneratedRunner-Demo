using UnityEngine;

namespace Gameplay.TrapLogic
{
    public class DamageTrigger: MonoBehaviour
    {
        public int Damage => damage;
        
        [SerializeField] private int damage;
    }
}
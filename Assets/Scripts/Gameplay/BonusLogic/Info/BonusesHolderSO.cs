using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.BonusLogic.Info
{
    [CreateAssetMenu(menuName = "Bonuses/Create BonusesHolderSO", fileName = "BonusesHolderSO", order = 0)]
    public class BonusesHolderSO: ScriptableObject
    {
        [SerializeField] private List<BonusInfo> bonuses;
        
        public BonusInfo GetBonus()
        {
            if (bonuses.Count > 0)
            {
                float randomValue = Random.value;
                float currentChance = 0;
                foreach (var bonus in bonuses)
                {
                    currentChance += bonus.SpawnChance;
                    if (randomValue <= currentChance)
                    {
                        return bonus;
                    }
                }
            }
            
            return null;
        }
    }
}
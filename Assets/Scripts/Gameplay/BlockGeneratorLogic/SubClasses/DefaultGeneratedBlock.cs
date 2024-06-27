using Gameplay.BonusLogic;
using Gameplay.BonusLogic.Info;
using Lean.Pool;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class DefaultGeneratedBlock: GeneratedBlock
    {
        [SerializeField] private Transform bonusSpawnPoint;

        private BonusesHolderSO _bonusesHolder;
        private GameObject _currentBonus;
        
        private void OnEnable()
        {
            TrySpawnBonus();
        }

        private void TrySpawnBonus()
        {
            if(_bonusesHolder == null)
            {
                _bonusesHolder = Resources.Load<BonusesHolderSO>(ResourcesPathHolder.BonusesHolder);
            }
            
            if (_currentBonus != null && _currentBonus.activeSelf == true)
            {
                LeanPool.Despawn(_currentBonus);
            }
            
            BonusInfo bonusInfo = _bonusesHolder.GetBonus();
            
            if(bonusInfo != null)
            {
                _currentBonus = LeanPool.Spawn(bonusInfo.Prefab, bonusSpawnPoint.position, transform.rotation, transform);
            }
        }
    }
}
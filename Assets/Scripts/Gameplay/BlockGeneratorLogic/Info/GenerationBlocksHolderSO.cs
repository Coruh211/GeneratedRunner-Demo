using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.BlockGeneratorLogic.Info
{
    [CreateAssetMenu(menuName = "Generation/Create GenerationBlocksHolderSo", fileName = "GenerationBlocksHolderSo", order = 0)]
    public class GenerationBlocksHolderSo: ScriptableObject
    {
        public GlobalBlockInfo StartBlockInfo
        {
            get
            {
                _lastBlockInfo = startBlockInfo;
                return startBlockInfo;
            }
        }
        
        public GlobalBlockInfo DefaultBlockInfo => defaultBlockInfo;
        
        public GlobalBlockInfo FinishBlockInfo
        {
            get
            {
                _lastBlockInfo = finishBlockInfo;
                return finishBlockInfo;
            }
        }
        
        [SerializeField] private GlobalBlockInfo startBlockInfo;
        [SerializeField] private GlobalBlockInfo defaultBlockInfo;
        [SerializeField] private GlobalBlockInfo finishBlockInfo;
        
        [SerializeField] private List<GlobalBlockInfo> Blocks;
        
        private GlobalBlockInfo _lastBlockInfo;
        private int _skipsCount;
        
        public GlobalBlockInfo GetRandomBlock()
        {
            if(_lastBlockInfo != null && _lastBlockInfo.AfterBlockSkip != _skipsCount)
            {
                _skipsCount++;
                return defaultBlockInfo;
            }
            
            _skipsCount = 0;
            
            float randomValue = Random.value;
            float currentChance = 0;
            for (int i = 0; i < Blocks.Count; i++)
            {
                currentChance += Blocks[i].SpawnChance;
                if (randomValue <= currentChance)
                {
                    _lastBlockInfo = Blocks[i];
                    return Blocks[i];
                }
            }
            
            return defaultBlockInfo;
        }
    }
}
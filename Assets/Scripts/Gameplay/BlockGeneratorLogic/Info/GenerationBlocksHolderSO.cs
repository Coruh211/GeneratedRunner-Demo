using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic.Info
{
    [CreateAssetMenu(menuName = "Generation/Create GenerationBlocksHolderSo", fileName = "GenerationBlocksHolderSo", order = 0)]
    public class GenerationBlocksHolderSo: ScriptableObject
    {
        public GenerationBlock StartBlock;
        public GenerationBlock FinishBlock;
        public List<GenerationBlock> Blocks;
        
        private GenerationBlock _lastBlock;
        private int _skipsCount;
        
        public GenerationBlock GetRandomBlock()
        {
            if(_lastBlock != null && _lastBlock.AfterBlockSkip != _skipsCount)
            {
                _skipsCount++;
                return GetDefaultBlock();
            }
            
            _skipsCount = 0;
            
            float randomValue = Random.value;
            float currentChance = 0;
            for (int i = 0; i < Blocks.Count; i++)
            {
                currentChance += Blocks[i].SpawnChance;
                if (randomValue <= currentChance)
                {
                    _lastBlock = Blocks[i];
                    return Blocks[i];
                }
            }
            return null;
        }

        private GenerationBlock GetDefaultBlock() => 
            Blocks.Find(block => block.BlockType == BlockType.Default);
    }
}
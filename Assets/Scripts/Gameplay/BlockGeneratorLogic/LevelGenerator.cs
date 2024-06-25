using System.Collections.Generic;
using System.Net.NetworkInformation;
using Gameplay.BlockGeneratorLogic.Info;
using Lean.Pool;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private int levelLength = 20;
        [SerializeField] private GenerationBlocksHolderSo generationBlocksHolder;
        [SerializeField] private Transform blocksParent;
        
        private List<GenerationBlock> _activeBlocks = new List<GenerationBlock>();
        
        public void GenerateLevel()
        {
            GenerationBlock startBlock = generationBlocksHolder.StartBlock;
            SpawnBlock(startBlock);
            
            for (int i = 0; i < levelLength; i++)
            {
                GenerationBlock block = generationBlocksHolder.GetRandomBlock();
                SpawnBlock(block);
            }
            
            GenerationBlock endBlock = generationBlocksHolder.FinishBlock;
            SpawnBlock(endBlock);
        }

        private void SpawnBlock(GenerationBlock block)
        {
            LeanPool.Spawn(block.Prefab, GetCurrentBlockPosition(), Quaternion.identity, blocksParent);
            _activeBlocks.Add(block);
        }

        private Vector3 GetCurrentBlockPosition()
        {
            float blocksLength = 0;
            for (int i = 0; i < _activeBlocks.Count; i++)
            {
                blocksLength += _activeBlocks[i].BlockLength;
            }
            
            return new Vector3(0, 0, blocksLength);
        }
    }
}
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Gameplay.BlockGeneratorLogic.Enums;
using Gameplay.BlockGeneratorLogic.Info;
using Lean.Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private int levelLength = 20;
        [SerializeField] private float findBlockDistance = 2f;
        [SerializeField] private GenerationBlocksHolderSo generationBlocksHolder;
        [SerializeField] private Transform blocksParent;
        [SerializeField] private GameObject changeDirectionBlocksContainer;
        
        private List<GeneratedBlock> _activeBlocks = new List<GeneratedBlock>();
        private List<GeneratedBlock> _currentContainerBlocks = new List<GeneratedBlock>();
        private List<GameObject> _containers = new List<GameObject>();
        private Transform _currentParent;
        
        [Button("Debug Generate Level")]
        public void GenerateLevel()
        {
            SetDefaultState();

            GlobalBlockInfo startBlockInfo = generationBlocksHolder.StartBlockInfo;
            SpawnBlock(startBlockInfo);
            
            for (int i = 0; i < levelLength; i++)
            {
                GlobalBlockInfo blockInfo = generationBlocksHolder.GetRandomBlock();
                SpawnBlock(blockInfo);
            }
            
            GlobalBlockInfo endBlockInfo = generationBlocksHolder.FinishBlockInfo;
            SpawnBlock(endBlockInfo);
        }

        private void SetDefaultState()
        {
            if (_activeBlocks.Count > 0)
            {
                for (int i = 0; i < _activeBlocks.Count; i++)
                {
                    LeanPool.Despawn(_activeBlocks[i]);
                }
            }
            
            if(_containers.Count > 0)
            {
                for (int i = 0; i < _containers.Count; i++)
                {
                    LeanPool.Despawn(_containers[i]);
                }
            }
            
            _currentParent = blocksParent;
            _activeBlocks.Clear();
            _containers.Clear();
        }

        private void SpawnBlock(GlobalBlockInfo blockInfo)
        {
            GeneratedBlock spawnedBlock = LeanPool.Spawn(blockInfo.Prefab, _currentParent);
            spawnedBlock.transform.localPosition = GetPosition(spawnedBlock);
            _activeBlocks.Add(spawnedBlock);
            _currentContainerBlocks.Add(spawnedBlock);

            DirectionSwitchTrap directionSwitchTrap = spawnedBlock as DirectionSwitchTrap;
            if (directionSwitchTrap != null)
            {
                _currentContainerBlocks.Clear();
                SpawnContainer(directionSwitchTrap);
            }
        }

        private Vector3 GetPosition(GeneratedBlock spawnedBlock)
        {
            if (_activeBlocks.Count == 0)
            {
                return Vector3.zero;
            }
            
            Vector3 position = Vector3.zero;
            
            if(_currentContainerBlocks.Count == 0)
            {
                position.z += _activeBlocks[^1].ModelTransform.localScale.z / 2 + spawnedBlock.ModelTransform.localScale.z / 2;
                return position;
            }

            position = _currentContainerBlocks[^1].transform.localPosition;
            position.z += _currentContainerBlocks[^1].ModelTransform.localScale.z / 2 + spawnedBlock.ModelTransform.localScale.z / 2;
            return position;
        }

        private void SpawnContainer(DirectionSwitchTrap spawnedBlock)
        {
            GameObject container = LeanPool.Spawn(changeDirectionBlocksContainer, _currentParent);
            _currentParent = container.transform;
            container.transform.position = _activeBlocks[^1].transform.position;
            container.transform.localRotation = spawnedBlock.TargetDirection == Direction.Left ? Quaternion.Euler(0, -90, 0) : Quaternion.Euler(0, 90, 0);
            _containers.Add(container);
            
            spawnedBlock.SetContainer(container);
        }

        public Vector3 FindNextBlock(Vector3 targetPosition)
        {
            int index = FindCurrentBlock(targetPosition);

            return _activeBlocks[index + 1].transform.position;
        }

        private int FindCurrentBlock(Vector3 targetPosition)
        {
            for (int i = _activeBlocks.Count - 1; i > 0; i--)
            {
                if (Vector3.Distance(targetPosition, _activeBlocks[i].transform.position) < findBlockDistance)
                {
                    return i;
                }
            }
            
            Debug.Log("I don't find block");
            return 0;
        }
    }
}
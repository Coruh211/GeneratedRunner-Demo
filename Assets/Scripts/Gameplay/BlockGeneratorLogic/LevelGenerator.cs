using System;
using System.Collections.Generic;
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
        [SerializeField] private Transform blocksParent;
        
        private List<GeneratedBlock> _activeBlocks = new List<GeneratedBlock>();
        private List<GeneratedBlock> _currentContainerBlocks = new List<GeneratedBlock>();
        private List<GameObject> _containers = new List<GameObject>();
        private GenerationBlocksHolderSo _generationBlocksHolder;
        private GameObject _changeDirectionBlocksContainer;
        private Transform _currentParent;
        
        [Button("Debug Generate Level")]
        public void GenerateLevel()
        {
            LoadRecourses(() =>
            {
                SetDefaultState();

                GlobalBlockInfo startBlockInfo = _generationBlocksHolder.StartBlockInfo;
                SpawnBlock(startBlockInfo);
            
                for (int i = 0; i < levelLength; i++)
                {
                    GlobalBlockInfo blockInfo = _generationBlocksHolder.GetRandomBlock();
                    SpawnBlock(blockInfo);
                }
            
                GlobalBlockInfo endBlockInfo = _generationBlocksHolder.FinishBlockInfo;
                SpawnBlock(endBlockInfo);
            });
        }

        private void LoadRecourses(Action OnLoadComplete = null)
        {
            if (_generationBlocksHolder == null)
            {
                _generationBlocksHolder = Resources.Load<GenerationBlocksHolderSo>(ResourcesPathHolder.GenerationBlocksHolder);
            }
            if(_changeDirectionBlocksContainer == null)
            {
                _changeDirectionBlocksContainer = Resources.Load<GameObject>(ResourcesPathHolder.ChangeDirectionBlocksContainer);
            }
            
            OnLoadComplete?.Invoke();
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

            DirectionSwitchBlock directionSwitchBlock = spawnedBlock as DirectionSwitchBlock;
            if (directionSwitchBlock != null)
            {
                _currentContainerBlocks.Clear();
                SpawnContainer(directionSwitchBlock);
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

        private void SpawnContainer(DirectionSwitchBlock spawnedBlock)
        {
            GameObject container = LeanPool.Spawn(_changeDirectionBlocksContainer, _currentParent);
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

        public List<GeneratedBlock> GetPassedBlocks(Transform playerTransform, bool isWin)
        {
            if (isWin)
            {
                return _activeBlocks;
            }
            
            List<GeneratedBlock> passedBlocks = new List<GeneratedBlock>();
            int index = FindCurrentBlock(playerTransform.position);
            
            for (int i = 0; i < index; i++)
            {
                passedBlocks.Add(_activeBlocks[i]);
            }

            return passedBlocks;
        }
    }
}
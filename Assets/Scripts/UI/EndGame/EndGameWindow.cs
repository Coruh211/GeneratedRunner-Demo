using System.Collections.Generic;
using Core;
using Gameplay.BlockGeneratorLogic;
using Lean.Pool;
using UnityEngine;

namespace UI.EndGame
{
    public class EndGameWindow : UIWindow
    {
        [SerializeField] private GameObject cellsContainer;
        [SerializeField] private GameObject cellPrefab;
        
        private List<GameObject> _activeCells = new List<GameObject>();
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
        }

        private void OnEnable()
        {
            FillBlocksList();
        }

        private void FillBlocksList()
        {
            var passedBlocksList = _gameManager.GetPassedBlocks();
            Dictionary<string, int> blockCounts = new Dictionary<string, int>();

            for (int i = 0; i < passedBlocksList.Count; i++)
            {
                if (passedBlocksList[i].BlockType == BlockType.Trap)
                {
                    Trap trap = passedBlocksList[i] as Trap;
                    if (blockCounts.ContainsKey(trap.TrapName))
                    {
                        blockCounts[trap.TrapName]++;
                    }
                    else
                    {
                        blockCounts[trap.TrapName] = 1;
                    }
                }
            }
            
            foreach (var blockCount in blockCounts)
            {
                var cell = LeanPool.Spawn(cellPrefab, cellsContainer.transform);
                cell.GetComponent<BlockUICell>().Initialize(blockCount.Value, blockCount.Key);
                _activeCells.Add(cell);
            }
        }
        private void OnDisable()
        {
            for (int i = 0; i < _activeCells.Count; i++)
            {
                LeanPool.Despawn(_activeCells[i]);
            }
            
            _activeCells.Clear();
        }
    }
}
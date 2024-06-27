using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Core;
using Gameplay.BlockGeneratorLogic;
using Gameplay.Player;
using ImportedTools.StarterPack.CoreLogic.Tools;
using Lean.Pool;
using UnityEngine;

namespace Gameplay
{
    public class LevelController : Singleton<LevelController>
    {
        [SerializeField] private LevelGenerator levelGenerator;
        
        private GameObject _playerPrefab;
        private PlayerLogic _player;
        private GameManager _gameManager;

        private void Awake()
        {
            _playerPrefab = Resources.Load<GameObject>(ResourcesPathHolder.Player);
            _gameManager = GameManager.Instance;
            GameManager.OnLevelStarted += InitializePlayer;
            
            PrepareLevel();
        }
        
        public void PrepareLevel()
        {
            levelGenerator.GenerateLevel();
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            if (_player != null)
            {
                LeanPool.Despawn(_player.gameObject);
            }

            _player = LeanPool.Spawn(_playerPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<PlayerLogic>();
        }

        private void InitializePlayer()
        {
            _player.Initialize(this);
        }
        
        public void EndGame(bool isWin)
        {
            _gameManager.EndLevel(isWin);
        }
        
        public Vector3 GetNextBlockFromPlayer()
        {
            return levelGenerator.FindNextBlock(_player.transform.position);
        }

        public List<GeneratedBlock> GetPassedBlocks(bool isWin)
        {
            return levelGenerator.GetPassedBlocks(_player.transform, isWin);
        }

        public void RevivePlayer()
        {
            _player.Respawn();
        }
    }
}
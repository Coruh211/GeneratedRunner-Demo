using System;
using System.Net.NetworkInformation;
using Core;
using Gameplay.BlockGeneratorLogic;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private PlayerLogic player;
        [SerializeField] private LevelGenerator levelGenerator;

        

        private void Awake()
        {
            GameManager.OnLevelStarted += InitializePlayer;
            levelGenerator.GenerateLevel();
        }

        private void InitializePlayer()
        {
            player.Initialize(this);
        }

        public void PlayerDie()
        {
            Debug.Log("PlayerDie");
        }
        
        public Vector3 GetNextBlockFromPlayer()
        {
            return levelGenerator.FindNextBlock(player.transform.position);
        }
    }
}
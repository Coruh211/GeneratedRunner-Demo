using Core;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private PlayerLogic player;
        private void Awake()
        {
            GameManager.OnLevelStarted += InitializePlayer;
        }

        private void InitializePlayer()
        {
            player.Initialize(this);
        }
    }
}
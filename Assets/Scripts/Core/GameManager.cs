using System;
using System.Collections.Generic;
using Gameplay;
using Gameplay.BlockGeneratorLogic;
using ImportedTools.StarterPack.CoreLogic.Tools;
using UI;
using UI.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager: Singleton<GameManager>
    {
        public static event Action OnLevelStarted;
        public static event Action<bool> OnLevelEnded;
        
        [SerializeField] private int gameSceneIndex = 1;

        private UIController _uiController;
        private bool _isWin;
        
        private void Awake()
        {
            _uiController = UIController.Instance;
            
           LoadLevel();
        }
        
        private void LoadLevel()
        {
            LoadGameState(MainState);
        }
        
        public void RestartLevel()
        {
            LevelController.Instance.PrepareLevel();
            _uiController.ActivateWindow(WindowType.MainMenuWindow);
        }

        private void MainState()
        {
            _uiController.ActivateWindow(WindowType.MainMenuWindow, true);
        }

        private void LoadGameState(Action onSceneLoaded = null)
        {
            _uiController.ActivateWindow(WindowType.LoadWindow);
            SceneManager.LoadScene(gameSceneIndex);
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                onSceneLoaded?.Invoke();
            };
        }

        public void StartLevel()
        {
            _uiController.ActivateWindow(WindowType.GameWindow);
            OnLevelStarted?.Invoke();
        }
        
        public void EndLevel(bool isWin)
        {
            OnLevelEnded?.Invoke(isWin);
            _isWin = isWin;
            _uiController.ActivateWindow(isWin ? WindowType.EndGameWinWindow : WindowType.EndGameLoseWindow);
        }

        public List<GeneratedBlock> GetPassedBlocks()
        {
            return LevelController.Instance.GetPassedBlocks(_isWin);
        }

        public void RevivePlayer()
        {
            LevelController.Instance.RevivePlayer();
            _uiController.ActivateWindow(WindowType.GameWindow);
        }
    }
}
using System;
using ImportedTools.StarterPack.CoreLogic.Tools;
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
        
        private void Awake()
        {
            _uiController = UIController.Instance;
            
            LoadGameState(() =>
            {
                MainState();
            });
        }

        private void MainState()
        {
            _uiController.SetWindowState(WindowType.MainMenuWindow, true);
        }

        private void LoadGameState(Action onSceneLoaded = null)
        {
            _uiController.SetWindowState(WindowType.LoadWindow, true);
            SceneManager.LoadScene(gameSceneIndex);
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                onSceneLoaded?.Invoke();
            };
        }

        public void StartLevel()
        {
            _uiController.SetWindowState(WindowType.GameWindow, true);
            OnLevelStarted?.Invoke();
        }
        
        public void EndLevel(bool isWin)
        {
            OnLevelEnded?.Invoke(isWin);
        }
    }
}
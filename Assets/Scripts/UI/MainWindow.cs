using Core;

namespace UI
{
    public class MainWindow : UIWindow
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
        }

        public void StartLevelClick()
        {
            _gameManager.StartLevel();
        }
    }
}
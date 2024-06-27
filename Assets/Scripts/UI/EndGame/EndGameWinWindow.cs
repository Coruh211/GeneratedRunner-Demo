using Core;

namespace UI.EndGame
{
    public class EndGameWinWindow: EndGameWindow
    {
        public void NextLevelClick()
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
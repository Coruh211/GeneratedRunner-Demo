using Core;

namespace UI.EndGame
{
    public class EndGameLoseWindow: EndGameWindow
    {
        public void RestartButtonClick()
        {
            GameManager.Instance.RestartLevel();
        }

        public void ReviveButtonClick()
        {
            GameManager.Instance.RevivePlayer();
        }
    }
}
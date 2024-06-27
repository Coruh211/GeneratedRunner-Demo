using UI.Enums;
using UnityEngine;

namespace UI
{
    public class UIWindow: MonoBehaviour
    {
        [SerializeField] private WindowType windowType;
        
        public void ActivateWindow(bool deactiveAllWindows = true, WindowType currentType = WindowType.Undefined)
        {
            if (currentType != windowType)
            {
                if (deactiveAllWindows)
                {
                    gameObject.SetActive(false);
                }
                return;
            }
            
            gameObject.SetActive(true);
        }
    }
}
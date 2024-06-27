using ImportedTools.StarterPack.CoreLogic.Tools;
using UI.Enums;
using UnityEngine;

namespace UI
{
    public class UIController: Singleton<UIController>
    {
        [SerializeField] private UIWindow[] windows;
        
        public void ActivateWindow(WindowType windowType, bool deactiveAllWindows = true)
        {
            foreach (var window in windows)
            {
                window.ActivateWindow(deactiveAllWindows, windowType);
            }
        }
    }
}
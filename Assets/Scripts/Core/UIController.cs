using System;
using ImportedTools.StarterPack.CoreLogic.Tools;
using UI;
using UI.Enums;
using UnityEngine;

namespace Core
{
    public class UIController: Singleton<UIController>
    {
        [SerializeField] private UIWindow[] windows;
        
        public void SetWindowState(WindowType windowType, bool state, bool deactiveAllWindows = true)
        {
            foreach (var window in windows)
            {
                window.SetState(state, deactiveAllWindows, windowType);
            }
        }
    }
}
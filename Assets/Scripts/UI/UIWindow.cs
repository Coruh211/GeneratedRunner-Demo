using UI.Enums;
using UnityEngine;

namespace UI
{
    public class UIWindow: MonoBehaviour
    {
        [SerializeField] private WindowType windowType;
        
        public void OnEnable()
        {
            Initialize();
        }

        public void SetState(bool state, bool deactiveAllWindows = true, WindowType currentType = WindowType.Undefined)
        {
            if (currentType != windowType)
            {
                if (deactiveAllWindows)
                {
                    gameObject.SetActive(false);
                }
                return;
            }
            
            gameObject.SetActive(state);
        }

        protected virtual void Initialize() {}
    }
}
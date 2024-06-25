using System;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;

namespace ImportedTools.StarterPack.CoreLogic.Tools.Ticker
{
    public class Ticker : Singleton<Ticker>
    {
        private event Action OnUpdate;
        private event Action OnLateUpdate;
        private event Action OnFixedUpdate;

        private static Ticker _instance;
        
        private void Awake() =>
            _instance = this;

        public static void RegisterUpdateable(IUpdateable updateable)
        {
            _instance.OnUpdate -= updateable.OnUpdate;
            _instance.OnUpdate += updateable.OnUpdate;
        }

        public static void RegisterLateUpdateable(ILateUpdateable lateUpdateable)
        {
            _instance.OnLateUpdate -= lateUpdateable.OnLateUpdate;
            _instance.OnLateUpdate += lateUpdateable.OnLateUpdate;
        }

        public static void RegisterFixedUpdateable(IFixedUpdateable fixedUpdateable)
        {
            _instance.OnLateUpdate -= fixedUpdateable.OnFixedUpdate;
            _instance.OnFixedUpdate += fixedUpdateable.OnFixedUpdate;
        }

        public static void UnregisterUpdateable(IUpdateable updateable) =>
            _instance.OnUpdate -= updateable.OnUpdate;

        public static void UnregisterLateUpdateable(ILateUpdateable lateUpdateable) =>
            _instance.OnLateUpdate -= lateUpdateable.OnLateUpdate;

        public static void UnregisterFixedUpdateable(IFixedUpdateable fixedUpdateable) =>
            _instance.OnFixedUpdate -= fixedUpdateable.OnFixedUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
    }
}
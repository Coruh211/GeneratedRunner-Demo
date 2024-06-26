using Gameplay.Player.Interfaces;
using ImportedTools.StarterPack.CoreLogic.Tools.Ticker;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class InfinityForwardMovement: ILogic, IUpdateable
    {
        private readonly Transform _transform;
        private readonly AnimatorController _animator;

        private readonly float _speed;
        
        public InfinityForwardMovement(float speed, Transform transform, AnimatorController animator)
        {
            _speed = speed;
            _transform = transform;
            _animator = animator;
        }

        public void Enter()
        {
            Ticker.RegisterUpdateable(this);
        }

        public void OnUpdate()
        {
            var targetTransformPosition = _transform.transform.position;
            targetTransformPosition.z += _speed * Time.deltaTime;
            _transform.transform.position = targetTransformPosition;
            _animator.SetMoveAnimation(true);
        }

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }
    }
}
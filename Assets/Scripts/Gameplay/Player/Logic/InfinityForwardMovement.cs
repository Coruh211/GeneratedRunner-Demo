using System;
using Gameplay.Player.Interfaces;
using ImportedTools.StarterPack.CoreLogic.Tools.Ticker;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using UniRx;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class InfinityForwardMovement: ILogic, IUpdateable
    {
        private readonly Transform _transform;
        private readonly AnimatorController _animator;
        private readonly Rigidbody _rigidbody;
        private readonly float _defaultSpeed;
        private float _speed;
        
        private IDisposable _interval;

        public InfinityForwardMovement(float speed,Rigidbody rigidbody,Transform transform, AnimatorController animator)
        {
            _speed = speed;
            _transform = transform;
            _animator = animator;
            _rigidbody = rigidbody;
        }

        public void Enter()
        {
            Ticker.RegisterUpdateable(this);
        }

        public void OnUpdate()
        {
            var targetTransformPosition = _transform.forward * _speed;
            _rigidbody.velocity = new Vector3(targetTransformPosition.x, _rigidbody.velocity.y, targetTransformPosition.z);
            _animator.SetMoveAnimation(true);
        }

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }

        public void ChangeSpeed(float speed, float time)
        {
            _speed = speed;
            float currentTime = 0;
            _interval?.Dispose();
            _interval = Observable.Interval(TimeSpan.FromSeconds(0.1f)).Subscribe(_ =>
            {
                currentTime += 0.1f;
                _speed = Mathf.Lerp(_speed, _defaultSpeed, currentTime / time);
                
                if (currentTime >= time)
                {
                    _interval.Dispose();
                    _speed = _defaultSpeed;
                }
            });
        }
    }
}
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
        private readonly float _intervalTickSec = 0.1f;
        private float _speed;
        
        private IDisposable _interval;
        private IDisposable _timer;
        
        public InfinityForwardMovement(MovementInfo movementInfo,Rigidbody rigidbody,Transform transform, AnimatorController animator)
        {
            _speed = movementInfo.DefaultMoveSpeed;
            _defaultSpeed = _speed;
            _transform = transform;
            _animator = animator;
            _rigidbody = rigidbody;
        }

        public void Enter()
        {
            Ticker.RegisterUpdateable(this);
            _speed = _defaultSpeed;
        }

        public void OnUpdate()
        {
            var targetTransformPosition = _transform.forward * _speed;
            _rigidbody.velocity = new Vector3(targetTransformPosition.x, _rigidbody.velocity.y, targetTransformPosition.z);
            _animator.SetMoveAnimation(true);
        }
        
        public void ChangeSpeed(float speed, float time, bool smoothDecrease)
        {
            _speed = _defaultSpeed;
            _speed = speed;
            
            _interval?.Dispose();
            _timer?.Dispose();
            
            if (smoothDecrease)
            {
                StartInterval(time);
            }
            else
            {
                StartTimer(time);
            }
        }

        private void StartTimer(float time)
        {
            _interval?.Dispose();
            _timer = Observable.Timer(TimeSpan.FromSeconds(time)).Subscribe(_ =>
            {
                _speed = _defaultSpeed;
            });
        }

        private void StartInterval(float time)
        {
            float currentTime = 0;
            _interval?.Dispose();
            _interval = Observable.Interval(TimeSpan.FromSeconds(_intervalTickSec)).Subscribe(_ =>
            {
                currentTime += _intervalTickSec;
                _speed = Mathf.Lerp(_speed, _defaultSpeed, currentTime / time);
                
                if (currentTime >= time)
                {
                    _interval.Dispose();
                    _speed = _defaultSpeed;
                }
            });
        }
        
        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
            _animator.SetMoveAnimation(false);
            _timer?.Dispose();
            _interval?.Dispose();
            _speed = _defaultSpeed;
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
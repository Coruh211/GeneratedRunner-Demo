using Gameplay.Player.Interfaces;
using ImportedTools.StarterPack.CoreLogic.Tools.Ticker;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class InfinityForwardMovement: ILogic, IUpdateable
    {
        private readonly Rigidbody _targetRigidbody;
        private readonly AnimatorController _animator;

        private readonly float _speed;
        
        public InfinityForwardMovement(float speed, Rigidbody targetRigidbody, AnimatorController animator)
        {
            _speed = speed;
            _targetRigidbody = targetRigidbody;
            _animator = animator;
        }

        public void Enter()
        {
            Ticker.RegisterUpdateable(this);
        }

        public void OnUpdate()
        {
            _targetRigidbody.velocity = new Vector3(_targetRigidbody.velocity.x, _targetRigidbody.velocity.y, _speed);
            _animator.SetMoveAnimation(true);
        }

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }
    }
}
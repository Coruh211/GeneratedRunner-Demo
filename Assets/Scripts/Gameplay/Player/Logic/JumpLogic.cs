using Gameplay.Player.Interfaces;
using ImportedTools.StarterPack.CoreLogic.Tools.Ticker;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class JumpLogic: ILogic, IUpdateable
    {
        private readonly Rigidbody _rigidbody;
        private readonly AnimatorController _animator;
        private readonly int _maxJumpCount;
        private readonly float _jumpForce;
        private int _currentJumpCount;
        
        public JumpLogic(int maxJumpCount, float jumpForce, Rigidbody rigidbody, AnimatorController animator)
        {
            _maxJumpCount = maxJumpCount;
            _jumpForce = jumpForce;
            _rigidbody = rigidbody;
            _animator = animator;
        }

        public void Enter()
        {
            Ticker.RegisterUpdateable(this);
        }
        
        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                CheckAbilityJump();
            }
        }
       

        private void CheckAbilityJump()
        {
            if (_rigidbody.velocity.y != 0 && _currentJumpCount >= _maxJumpCount)
            {
                return;
            }
            
            if (_rigidbody.velocity.y == 0)
            {
                _currentJumpCount = 0;
            }
            
            Jump();
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _currentJumpCount++;
            
            _animator.SetJumpAnimation();
        }
        

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }
    }
}
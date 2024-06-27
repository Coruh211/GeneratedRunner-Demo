using Gameplay.Player.Interfaces;
using Gameplay.Player.SubPakage;
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
        private bool _isGrounded;
        
        public JumpLogic(JumpLogicInfo jumpLogicInfo, Rigidbody rigidbody, AnimatorController animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;

            _maxJumpCount = jumpLogicInfo.MaxJumpCount;
            _jumpForce = jumpLogicInfo.JumpForce;
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
            if (_isGrounded)
            {
                _currentJumpCount = 0;
            }
            
            if (_currentJumpCount >= _maxJumpCount)
            {
                return;
            }
            
            Jump();
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _currentJumpCount++;
            _isGrounded = false;
            
            _animator.SetJumpAnimation();
        }
        
        public void SetGrounded(bool value)
        {
            _isGrounded = value;
        }
        
        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }
    }
}
using Gameplay.Player.Interfaces;
using ImportedTools.StarterPack.CoreLogic.Tools.Ticker;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using UnityEngine;

namespace Gameplay.Player
{
    internal class JumpLogic: IPlayerLogic, IUpdateable
    {
        private readonly PlayerInfo _playerInfo;
        private int _currentJumpCount;
        private readonly int _maxJumpCount;

        public JumpLogic(PlayerInfo playerInfo)
        {
            _playerInfo = playerInfo;
            _maxJumpCount = playerInfo.MaxJumpCount;
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
            if (_playerInfo.IsGrounded == false)
            {
                return;
            }
            
            _currentJumpCount = 0;
            Jump();
        }

        private void Jump()
        {
            if (_currentJumpCount < _maxJumpCount)
            {
                _playerInfo.Rigidbody.AddForce(Vector3.up * _playerInfo.JumpForce, ForceMode.Impulse);
                _currentJumpCount++;
            }
        }

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }
    }
}
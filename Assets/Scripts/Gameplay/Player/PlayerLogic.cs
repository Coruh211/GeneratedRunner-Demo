using System;
using Gameplay.BonusLogic;
using Gameplay.Player.Interfaces;
using Gameplay.Player.Logic;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerLogic: MonoBehaviour, IMovement, IHoldHp
    {
        private PlayerInfo _playerInfo;
        private LevelController _levelController;
        private InfinityForwardMovement _infinityForwardMovement;
        private JumpLogic _jumpLogic;
        private HpLogic _hpLogic;
        private ActivateBonusLogic _activateBonusLogic;
        private bool _isDie;
        private bool _isInitialized;

        private void Awake()
        {
            _playerInfo = GetComponent<PlayerInfo>();
        }

        public void Initialize(LevelController levelController)
        {
            _levelController = levelController;
            _playerInfo.Rigidbody.isKinematic = false;
            InitializeLogic();
        }

        private void InitializeLogic()
        {
            if (_isInitialized == false)
            {
                _isInitialized = true;
                _infinityForwardMovement = new InfinityForwardMovement(_playerInfo.MovementInfo, _playerInfo.Rigidbody, transform, _playerInfo.Animator);
                _jumpLogic = new JumpLogic(_playerInfo.JumpLogicInfo, _playerInfo.Rigidbody, _playerInfo.Animator);
                _hpLogic = new HpLogic(_playerInfo.HpLogicInfo, this);
                _activateBonusLogic = new ActivateBonusLogic(this);
            }

            EnterLogic();
        }

        private void EnterLogic()
        {
            _infinityForwardMovement.Enter();
            _jumpLogic.Enter();
            _hpLogic.Enter();
        }
        
        public void ChangeIsGroundedState(bool isGrounded) => 
            _jumpLogic?.SetGrounded(isGrounded);

        public void ChangeDirection(Transform targetRotation, Vector3 targetPosition)
        {
            SetPosition(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
            transform.rotation = targetRotation.rotation;
        }
        
        public void ChangeSpeed(float speed, float time, bool smoothDecrease) => 
            _infinityForwardMovement.ChangeSpeed(speed, time, smoothDecrease);

        public void ChangeHp(int value, bool playRemoveParticle) => 
            _hpLogic.ChangeHp(value, playRemoveParticle);
        
        public void SetInvulnerability(float activeTime) => 
            _hpLogic.SetInvulnerability(activeTime);

        public void Die()
        {
            _isDie = true;
            ExitLogic();
        }
        
        public void EndGame() => 
            ExitLogic();

        public void DamageAndMoveToNextBlock(int damage, bool playDamageParticle)
        {
            ChangeHp(damage, playDamageParticle);
            SetPosition(_levelController.GetNextBlockFromPlayer());
        }

        public void Respawn()
        {
            _isDie = false;
            SetPosition(_levelController.GetNextBlockFromPlayer());
            EnterLogic();
            _infinityForwardMovement.ChangeSpeed(_playerInfo.MovementInfo.ReviveMoveSpeed, _playerInfo.MovementInfo.ReviveSpeedChangeTime, true);
        }

        private void SetPosition(Vector3 position) => 
            transform.position = position;

        public void ApplyBonus(Bonus bonus) => 
            _activateBonusLogic.ApplyBonus(bonus);

        private void ExitLogic()
        {
            _levelController.EndGame(!_isDie);
            _infinityForwardMovement.Exit();
            _jumpLogic.Exit();
            _hpLogic.Exit();
        }
    }
}
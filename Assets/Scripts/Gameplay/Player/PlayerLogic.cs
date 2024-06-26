using Gameplay.BlockGeneratorLogic;
  using Gameplay.BlockGeneratorLogic.Enums;
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
            _infinityForwardMovement = new InfinityForwardMovement(_playerInfo.DefaultMoveSpeed, _playerInfo.Rigidbody, transform, _playerInfo.Animator);
            _jumpLogic = new JumpLogic(_playerInfo.JumpLogicInfo, _playerInfo.Rigidbody, _playerInfo.Animator);
            _hpLogic = new HpLogic(this, _playerInfo.MaxHp, _playerInfo.RemoveHpParticle);

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
        
        public void ChangeSpeed(float speed, float time) => 
            _infinityForwardMovement.ChangeSpeed(speed, time);

        public void ChangeHp(int value, bool playRemoveParticle) => 
            _hpLogic.ChangeHp(value, playRemoveParticle);

        public void Die()
        {
            _levelController.PlayerDie();
            ExitLogic();
        }

        private void ExitLogic()
        {
            _infinityForwardMovement.Exit();
            _jumpLogic.Exit();
            _hpLogic.Exit();
        }

        public void Fell(int damage, bool playDamageParticle)
        {
             ChangeHp(damage, playDamageParticle);
             SetPosition(_levelController.GetNextBlockFromPlayer());
        }

        private void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
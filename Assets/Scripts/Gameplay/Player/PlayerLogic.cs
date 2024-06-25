  using Gameplay.Player.Logic;
  using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerLogic: MonoBehaviour
    {
        private PlayerInfo _playerInfo;
        private LevelController _levelController;
        private InfinityForwardMovement _infinityForwardMovement;
        private JumpLogic _jumpLogic;
        

        private void Awake()
        {
            _playerInfo = GetComponent<PlayerInfo>();
        }

        public void Initialize(LevelController levelController)
        {
            _levelController = levelController;
            
            InitializeLogic();
        }

        private void InitializeLogic()
        {
            _infinityForwardMovement = new InfinityForwardMovement(_playerInfo);
            _jumpLogic = new JumpLogic(_playerInfo);

            EnterLogic();
        }

        private void EnterLogic()
        {
            _infinityForwardMovement.Enter();
            _jumpLogic.Enter();
        }
        
        public bool IsGrounded()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0,0,1), Vector3.down, out hit, _playerInfo.GroundCheckDistance, _playerInfo.GroundLayer))
            {
                Debug.Log("Grounded");
                return true;
            }
            
            Debug.Log("Not Grounded");

            return false;
        }
    }
}
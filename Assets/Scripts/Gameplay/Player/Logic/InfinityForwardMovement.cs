using Gameplay.Player.Interfaces;
using ImportedTools.StarterPack.CoreLogic.Tools.Ticker;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class InfinityForwardMovement: IPlayerLogic, IUpdateable
    {
        private readonly float _speed;
        private readonly Rigidbody _targetRigidbody;

        public InfinityForwardMovement(PlayerInfo playerInfo)
        {
            _speed = playerInfo.MoveSpeed;
            _targetRigidbody = playerInfo.Rigidbody;
        }

        public void Enter()
        {
            Ticker.RegisterUpdateable(this);
        }

        public void OnUpdate()
        {
            _targetRigidbody.velocity = new Vector3(_targetRigidbody.velocity.x, _targetRigidbody.velocity.y, _speed);
        }

        public void Exit()
        {
            Ticker.UnregisterUpdateable(this);
        }
    }
}
using UnityEngine;

namespace Gameplay.Player.Interfaces
{
    public interface IMovement
    {
        void ChangeSpeed(float speed, float time);
        void ChangeDirection(Transform targetRotation, Vector3 targetPosition);
        void ChangeIsGroundedState(bool isGrounded);
    }
}
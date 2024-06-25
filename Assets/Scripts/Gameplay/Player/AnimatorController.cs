using System.Net.NetworkInformation;
using UnityEngine;

namespace Gameplay.Player
{
    public class AnimatorController: MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private readonly int _move = Animator.StringToHash("Move");
        private readonly int _jump = Animator.StringToHash("Jump");

        public void SetMoveAnimation(bool isMoving)
        {
            animator.SetBool(_move, isMoving);
        }
        
        public void SetJumpAnimation()
        {
            animator.SetTrigger(_jump);
        }
    }
}
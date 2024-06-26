using UnityEditor;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private PlayerLogic playerLogic;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                playerLogic.IsGrounded(true);
            }
        }
    }
}
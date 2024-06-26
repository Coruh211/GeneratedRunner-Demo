using Gameplay.BlockGeneratorLogic.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class GeneratedBlock: MonoBehaviour
    {
        public Transform ModelTransform => modelTransform;
        
        [SerializeField] private Transform modelTransform;
    }
}
using Gameplay.BlockGeneratorLogic.Enums;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class GeneratedBlock: MonoBehaviour
    {
        public Transform ModelTransform => modelTransform;
        public BlockType BlockType => blockType;
        
        [SerializeField] private BlockType blockType;
        [SerializeField] private Transform modelTransform;
    }
}
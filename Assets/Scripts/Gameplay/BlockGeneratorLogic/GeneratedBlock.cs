using Gameplay.BlockGeneratorLogic.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class GeneratedBlock: MonoBehaviour
    {
        public BlockType BlockType => blockType;
        public bool ItsChangeDirection => itsChangeDirection;
        public Direction TargetDirection => targetDirection;

        public Transform BlockTransform => blockTransform;

        [EnumToggleButtons] 
        [SerializeField] private BlockType blockType;
        [SerializeField] private Transform blockTransform;
        [ShowIf("blockType", BlockType.Trap)] 
        [SerializeField] private bool itsChangeDirection;
        [ShowIf("itsChangeDirection")] 
        [SerializeField] private Direction targetDirection;
    }
}
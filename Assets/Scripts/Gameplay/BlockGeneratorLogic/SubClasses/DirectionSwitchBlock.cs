using Gameplay.BlockGeneratorLogic.Enums;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic.SubClasses
{
    public class DirectionSwitchBlock : GeneratedBlock
    {
        public GameObject CurrentContainer => _currentContainer;
        public Direction TargetDirection => targetDirection;
        
        [SerializeField] private Direction targetDirection;
        
        private GameObject _currentContainer;

        public void SetContainer(GameObject container)
        {
            _currentContainer = container;
        }
    }
}
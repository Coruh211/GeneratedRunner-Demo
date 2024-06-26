using Gameplay.BlockGeneratorLogic.Enums;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class DirectionSwitchTrap : Trap
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
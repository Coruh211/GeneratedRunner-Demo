using Gameplay.BlockGeneratorLogic.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class Trap : GeneratedBlock
    {
        public TrapType TrapType => trapType;
        
        [SerializeField] private TrapType trapType;
    }
}
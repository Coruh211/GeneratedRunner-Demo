using Gameplay.BlockGeneratorLogic.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    public class Trap : GeneratedBlock
    {
        public string TrapName => trapName;

        [SerializeField] private string trapName;
    }
}
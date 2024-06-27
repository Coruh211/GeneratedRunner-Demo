using UnityEngine;

namespace Gameplay.BlockGeneratorLogic.SubClasses
{
    public class Trap : GeneratedBlock
    {
        public string TrapName => trapName;

        [SerializeField] private string trapName;
    }
}
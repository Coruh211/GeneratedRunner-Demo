using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic
{
    [Serializable]
    public class GenerationBlock
    {
        public GameObject Prefab;
        [Tooltip("Какая длинна у блока")]
        public float BlockLength = 2.5f;
        [Tooltip("Сколько блоков будут дефолтными после этого блока")]
        public int AfterBlockSkip;
        [EnumToggleButtons]
        public BlockType BlockType;
        [Range(0,1), ShowIf("BlockType", BlockType.Trap)]
        public float SpawnChance;
        
        
    }
    
    public enum BlockType
    {
        Cosmetic,
        Default,
        Trap
    }
}
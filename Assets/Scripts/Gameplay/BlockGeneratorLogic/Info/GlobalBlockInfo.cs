using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.BlockGeneratorLogic.Info
{
    [Serializable]
    public class GlobalBlockInfo
    {
        public GeneratedBlock Prefab;
        public bool SetSettings = true;
        [ShowIf("SetSettings")]
        [Range(0,1)]
        public float SpawnChance;
        [ShowIf("SetSettings")]
        [Tooltip("Сколько блоков будут дефолтными после этого блока")]
        public int AfterBlockSkip;
    }
}
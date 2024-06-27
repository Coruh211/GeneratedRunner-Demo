using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.BlockGeneratorLogic.Info
{
    [Serializable]
    public class GlobalBlockInfo
    {
        public GeneratedBlock Prefab => prefab;
        public float SpawnChance => spawnChance;
        public int AfterBlockSkip => afterBlockSkip;
        
        [SerializeField] private GeneratedBlock prefab;
        [SerializeField] private bool setSettings = true;
        [ShowIf("setSettings")]
        [Range(0,1)]
        [SerializeField] private float spawnChance;
        [ShowIf("setSettings")]
        [Tooltip("Сколько блоков будут дефолтными после этого блока")]
        [SerializeField] private int afterBlockSkip;
    }
}
using System;
using UnityEngine;

namespace Gameplay.BonusLogic.Info
{
    [Serializable]
    public class BonusInfo
    {
        public GameObject Prefab => prefab;
        public float SpawnChance => spawnChance;
        
        [SerializeField] private GameObject prefab;
        [Range(0,1)]
        [SerializeField] private float spawnChance;
    }
}
using System;
using System.Net.NetworkInformation;
using Gameplay.BonusLogic.Enums;
using Gameplay.BonusLogic.Info;
using Lean.Pool;
using UnityEngine;

namespace Gameplay.BonusLogic
{
    public class Bonus : MonoBehaviour
    {
        public BonusType BonusType => bonusType;

        [SerializeField] private BonusType bonusType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                LeanPool.Despawn(gameObject);
            }
        }
    }
}
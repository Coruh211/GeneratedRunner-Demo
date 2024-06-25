using System;
using DG.Tweening;
using UnityEngine;

namespace Gameplay.TrapAnimationsLogic
{
    public class SpinAnimation : MonoBehaviour
    {
        [SerializeField] private float oneCircleTime = 1f;

        private void Awake()
        {
            StartSpin();
        }

        private void StartSpin()
        {
            transform.DORotate(new Vector3(0, 0, 360), oneCircleTime, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }
    }
}
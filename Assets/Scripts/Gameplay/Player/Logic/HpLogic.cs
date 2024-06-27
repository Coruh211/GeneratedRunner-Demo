using System;
using Gameplay.Player.Interfaces;
using Gameplay.Player.SubPakage;
using TMPro;
using UniRx;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class HpLogic: ILogic
    {
        private readonly ParticleSystem _removeHpParticle;
        private readonly TextMeshProUGUI _hpText;
        private readonly IHoldHp _holdHpObj;
        private readonly int _maxHp;
        
        private bool _canTakeDamage = true;
        private int _currentHp;
        private IDisposable _timer;
       
        public HpLogic(HpLogicInfo playerInfoHpLogicInfo, IHoldHp holdHpObj)
        {
            _holdHpObj = holdHpObj;
            _maxHp = playerInfoHpLogicInfo.MaxHp;
            _removeHpParticle = playerInfoHpLogicInfo.RemoveHpParticle;
            _hpText = playerInfoHpLogicInfo.HpText;
        }

        public void Enter()
        {
            _currentHp = _maxHp;
            SetText(_currentHp);
        }
        
        public void Damage(int value)
        {
            if (_canTakeDamage == false)
            {
                return;
            }
            
            _currentHp -= value;
            _removeHpParticle.Play();
            
            if (_currentHp <= 0)
            {
                _currentHp = 0;
                _holdHpObj.Die();
            }
            
            SetText(_currentHp);
        }
        
        public void Heal(int value)
        {
            _currentHp += value;
            
            if (_currentHp > _maxHp)
            {
                _currentHp = _maxHp;
            }
            
            SetText(_currentHp);
        }
        
        private void SetText(int value)
        {
            _hpText.text = value + " HP";
        }
        
        public void SetInvulnerability(float activeTime)
        {
            _canTakeDamage = false;
            _timer?.Dispose();

            _timer = Observable.Timer(TimeSpan.FromSeconds(activeTime)).Subscribe(_ =>
            {
                _canTakeDamage = true;
            });
        }
        
        public void Exit()
        {
            _timer?.Dispose();
            _canTakeDamage = true;
        }
    }
}
using Gameplay.Player.Interfaces;
using UnityEngine;

namespace Gameplay.Player.Logic
{
    internal class HpLogic: ILogic
    {
        private readonly ParticleSystem _removeHpParticle;
        private readonly IHoldHp _holdHpObj;
        private readonly int _maxHp;
        private int _currentHp;
        

        public HpLogic(IHoldHp holdHpObj, int maxHp, ParticleSystem removeHpParticle)
        {
            _holdHpObj = holdHpObj;
            _maxHp = maxHp;
            _removeHpParticle = removeHpParticle;
        }
        
        public void Enter()
        {
            _currentHp = _maxHp;
        }
        
        public void ChangeHp(int value, bool playRemoveParticle)
        {
            _currentHp += value;

            if (playRemoveParticle)
            {
                _removeHpParticle.Play();
            }
            
            if (_currentHp <= 0)
            {
                _holdHpObj.Die();
            }
            
            if (_currentHp > _maxHp)
            {
                _currentHp = _maxHp;
            }
        }
        
        public void Exit()
        {
            
        }
    }
}
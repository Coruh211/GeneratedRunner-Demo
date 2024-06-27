using System;
using Gameplay.BonusLogic;
using Gameplay.BonusLogic.Info;
using Gameplay.BonusLogic.SubClasses;
using Gameplay.Player.Interfaces;

namespace Gameplay.Player.Logic
{
    internal class ActivateBonusLogic: ILogic
    {
        private readonly PlayerLogic _playerLogic;
        
        public ActivateBonusLogic(PlayerLogic playerLogic)
        {
            _playerLogic = playerLogic;
        }

        public void Enter() { }
        
        public void ApplyBonus(Bonus bonus)
        {
            switch (bonus.BonusType)
            {
                case BonusType.SpeedUp:
                    SpeedUpBonus speedUpBonus = bonus as SpeedUpBonus;
                    _playerLogic.ChangeSpeed(speedUpBonus.NewSpeed, speedUpBonus.ActiveTime, false);
                    break;
                case BonusType.Heal:
                    HealBonus healBonus = bonus as HealBonus;
                    _playerLogic.Heal(healBonus.HealValue);
                    break;
                case BonusType.Invulnerability:
                    InvulnerabilityBonus invulnerabilityBonus = bonus as InvulnerabilityBonus;
                    _playerLogic.SetInvulnerability(invulnerabilityBonus.ActiveTime);
                    break;
            }
        }
        
        public void Exit() { }
    }
}
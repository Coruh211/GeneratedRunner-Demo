namespace Gameplay.Player.Interfaces
{
    public interface IHoldHp
    {
        public void Damage(int value);
        public void Heal(int value);
        public void SetInvulnerability(float activeTime);
        public void Die();
    }
}
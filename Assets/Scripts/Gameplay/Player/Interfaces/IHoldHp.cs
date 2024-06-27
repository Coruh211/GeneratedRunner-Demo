namespace Gameplay.Player.Interfaces
{
    public interface IHoldHp
    {
        void ChangeHp(int value, bool playRemoveParticle);
        public void SetInvulnerability(float activeTime);
        void Die();
    }
}
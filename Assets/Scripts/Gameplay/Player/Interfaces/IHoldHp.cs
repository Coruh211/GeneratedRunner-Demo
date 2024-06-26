namespace Gameplay.Player.Interfaces
{
    public interface IHoldHp
    {
        void ChangeHp(int value, bool playRemoveParticle);
        void Die();
    }
}
namespace Console_Game
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(int damage);

        void Heal(int value);
    }
}
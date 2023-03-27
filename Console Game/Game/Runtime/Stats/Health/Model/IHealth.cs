namespace ConsoleGame
{
    public interface IHealth : IReadOnlyHealth
    {
        void TakeDamage(int damage);

        void Heal(int value);
    }
}
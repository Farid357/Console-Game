namespace Console_Game
{
    public interface IHealth
    {
        int Value { get; }

        bool IsAlive { get; }
        
        bool IsDied { get; }

        void TakeDamage(int damage);

        void Heal(int value);
    }
}
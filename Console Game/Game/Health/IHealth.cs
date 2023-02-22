namespace Console_Game
{
    public interface IHealth
    {
        int Value { get; }
        
        int MaxValue { get; }

        bool IsAlive { get; }

        bool CanHeal(int value);
        
        void TakeDamage(int damage);

        void Heal(int value);
    }
}
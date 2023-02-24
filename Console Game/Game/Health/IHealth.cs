namespace Console_Game
{
    public interface IHealth
    {
        int Value { get; }
        
        int MaxValue { get; }

        bool IsAlive { get; }

        bool CanTakeDamage(int damage);
        
        void TakeDamage(int damage);

    }
}
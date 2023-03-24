namespace Console_Game
{
    public interface IReadOnlyHealth
    {
        int Value { get; }
        
        int MaxValue { get; }

        bool IsAlive { get; }

        bool CanHeal(int value);

    }
}
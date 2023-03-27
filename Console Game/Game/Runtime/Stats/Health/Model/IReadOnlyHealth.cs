namespace ConsoleGame
{
    public interface IReadOnlyHealth
    {
        int Value { get; }
        
        bool IsAlive { get; }

        bool CanHeal(int value);

    }
}
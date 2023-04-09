namespace ConsoleGame
{
    public interface IReadOnlyHealth : IReadOnlyGameObject
    {
        int Value { get; }
        
        bool CanHeal(int value);

    }
}
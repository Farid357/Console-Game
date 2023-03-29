namespace ConsoleGame
{
    public interface ICharacter
    {
        IHealth Health { get; }
        
        IReadOnlyTransform Transform { get; }
    }
}
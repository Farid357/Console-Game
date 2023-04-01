namespace ConsoleGame
{
    public interface IReadOnlyTimer
    {
        float Time { get; }
        
        bool IsEnded { get; }
    }
}
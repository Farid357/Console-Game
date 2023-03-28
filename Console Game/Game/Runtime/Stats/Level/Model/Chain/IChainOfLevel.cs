namespace ConsoleGame.Stats
{
    public interface IChainOfLevel : ILevel
    {
        ILevel CurrentLevel { get; }
        
        int CurrentLevelIndex { get; }
    }
}
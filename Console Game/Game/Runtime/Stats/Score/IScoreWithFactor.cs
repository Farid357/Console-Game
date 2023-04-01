namespace ConsoleGame.Stats
{
    public interface IScoreWithFactor : IScore
    {
        void ResetFactor();
        
        void IncreaseFactor(int value);
    }
}
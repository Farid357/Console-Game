namespace ConsoleGame
{
    public interface IScoreBestRecordFactory
    {
        IScoreBestRecord Create(IScore score);
    }
}
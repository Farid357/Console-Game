namespace Console_Game.Score
{
    public interface IScoreBestRecordFactory
    {
        IScoreBestRecord Create(IScore score);
    }
}
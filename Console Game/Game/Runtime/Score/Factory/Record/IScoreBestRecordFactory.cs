namespace Console_Game
{
    public interface IScoreBestRecordFactory
    {
        IScoreBestRecord Create(IScore score);
    }
}
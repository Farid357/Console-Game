namespace ConsoleGame
{
    public interface IScoreBestRecordViewFactory
    {
        IScoreBestRecordView Create(int bestRecord);
    }
}
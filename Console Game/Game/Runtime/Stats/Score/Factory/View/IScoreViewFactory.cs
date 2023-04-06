namespace ConsoleGame
{
    public interface IScoreViewFactory
    {
        IScoreView Create(int score);
    }
}
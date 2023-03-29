namespace ConsoleGame
{
    public interface IScoreAchievementView
    {
        void ReceiveWithCongratulations(int needScore, int currentScore);
    }
}
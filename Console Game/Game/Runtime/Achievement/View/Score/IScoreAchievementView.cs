namespace ConsoleGame
{
    public interface IScoreAchievementView
    {
        void Receive();
        
        void ReceiveWithCongratulations(int needScore, int currentScore);
    }
}
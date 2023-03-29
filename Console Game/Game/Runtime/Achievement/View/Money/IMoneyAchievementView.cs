namespace ConsoleGame
{
    public interface IMoneyAchievementView
    {
        void Receive();
        
        void ReceiveWithCongratulations(int needMoney);
    }
}
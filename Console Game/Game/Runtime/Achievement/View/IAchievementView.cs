namespace ConsoleGame
{
    public interface IAchievementView
    {
        void Receive();
        
        void ReceiveWithCongratulation(string congratulation);
    }
}
namespace ConsoleGame
{
    public interface IAchievement
    {
        bool CanReceive { get; }

        void Receive();
    }
}
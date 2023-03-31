namespace ConsoleGame
{
    public interface IReward
    {
        bool WasReceived { get; }

        void Receive();
    }
}
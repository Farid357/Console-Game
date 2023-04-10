namespace ConsoleGame
{
    public interface IBonusLoopFactory
    {
        void StartCreate(int minCreateDelay, int maxCreateDelay);
    }
}
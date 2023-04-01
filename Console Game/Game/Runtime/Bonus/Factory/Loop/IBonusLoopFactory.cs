namespace ConsoleGame.Bonus
{
    public interface IBonusLoopFactory
    {
        void StartCreate(int minCreateDelay, int maxCreateDelay);
    }
}
namespace ConsoleGame.Stats
{
    public interface IFactor
    {
        void Reset();
        
        void Increase(int value);
    }
}
namespace Console_Game.Stats
{
    public interface ILevel
    {
        int Xp { get; }

        bool IsFull();
        
        bool CanIncrease(int xp);
        
        void Increase(int xp);
    }
}
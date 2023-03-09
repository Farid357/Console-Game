namespace Console_Game
{
    public interface IEnemyLife
    {
        bool IsCompleted { get; }
        
        IEnemyLifePeriod CurrentPeriod { get; }

        void Continue();

        void Restart();

        void Stop();
    }
}
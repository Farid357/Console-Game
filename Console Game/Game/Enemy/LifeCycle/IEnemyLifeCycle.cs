namespace Console_Game
{
    public interface IEnemyLifeCycle : IGameLoopObject
    {
        bool IsCompleted { get; }
        
        IEnemyLifeCyclePeriod CurrentPeriod { get; }

        void Continue();

        void Restart();

        void Stop();
    }
}
namespace Console_Game
{
    public interface IEnemyLifePeriod : IGameLoopObject
    {
        bool IsCompleted { get; }
    }

    public sealed class EnemyMovePeriod : IEnemyLifePeriod
    {
        private readonly IAdjustableMovement _enemyMovement;
        
        public void Update(long deltaTime)
        {
            
        }

        public bool IsCompleted { get; }
    }
}
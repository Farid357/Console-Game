namespace Console_Game
{
    public interface IEnemyLifeCyclePeriod : IGameLoopObject
    {
        bool IsCompleted { get; }
    }

    public sealed class EnemyMovePeriod : IEnemyLifeCyclePeriod
    {
        private readonly IEnemyMovement _enemyMovement;
        
        public void Update(float deltaTime)
        {
            
        }

        public bool IsCompleted { get; }
    }
}
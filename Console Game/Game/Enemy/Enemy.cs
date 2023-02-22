using System;

namespace Console_Game
{
    public sealed class Enemy : IEnemy
    {
        public Enemy(IHealth health, IEnemyMovement movement, IEnemyData data)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Movement = movement ?? throw new ArgumentNullException(nameof(movement));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IHealth Health { get; }

        public IEnemyMovement Movement { get; }

        public IEnemyData Data { get; }
    }
}
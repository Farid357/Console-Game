using System;

namespace ConsoleGame
{
    public sealed class Enemy : IEnemy, IGameObject
    {
        public Enemy(IHealth health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public IHealth Health { get; }

        public bool IsActive => Health.IsAlive;

        public void Update(float deltaTime)
        {
            if (!IsActive)
                throw new InvalidOperationException($"Enemy isn't active1");
            
        }
    }
}
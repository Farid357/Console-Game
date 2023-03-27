using System;

namespace ConsoleGame
{
    public sealed class Enemy : IEnemy
    {
        public Enemy(IHealth health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public IHealth Health { get; }

        public bool IsAlive => Health.IsAlive;

    }
}
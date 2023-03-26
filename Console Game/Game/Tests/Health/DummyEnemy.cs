using System;

namespace ConsoleGame.Tests
{
    public sealed class DummyEnemy : IEnemy
    {
        public DummyEnemy(IHealth health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public IHealth Health { get; }
    }
}
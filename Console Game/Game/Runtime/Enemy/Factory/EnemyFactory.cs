using System;
using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly IHealthFactory _healthFactory;
        private readonly IEnemyBehaviourTreeFactory _behaviourTreeFactory;
        private readonly IMovementFactory _movementFactory;

        public EnemyFactory(IHealthFactory healthFactory, IEnemyBehaviourTreeFactory behaviourTreeFactory, IMovementFactory movementFactory)
        {
            _healthFactory = healthFactory ?? throw new ArgumentNullException(nameof(healthFactory));
            _behaviourTreeFactory = behaviourTreeFactory ?? throw new ArgumentNullException(nameof(behaviourTreeFactory));
            _movementFactory = movementFactory ?? throw new ArgumentNullException(nameof(movementFactory));
        }

        public IEnemy Create(ITransform transform)
        {
            IHealth health = _healthFactory.Create();
            IAdjustableMovement movement = _movementFactory.Create(transform);
            IEnemy enemy = new Enemy(health, _behaviourTreeFactory.Create(movement), movement);
            return enemy;
        }
    }
}
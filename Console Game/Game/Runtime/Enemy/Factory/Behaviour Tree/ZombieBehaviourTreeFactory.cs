using System;
using BananaParty.BehaviorTree;

namespace ConsoleGame
{
    public class ZombieBehaviourTreeFactory : IEnemyBehaviourTreeFactory
    {
        private readonly IHealth _characterHealth;
        private readonly IReadOnlyTransform _characterTransform;

        public ZombieBehaviourTreeFactory(IHealth characterHealth, IReadOnlyTransform characterTransform)
        {
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            _characterTransform = characterTransform ?? throw new ArgumentNullException(nameof(characterTransform));
        }

        public IBehaviorNode Create(IMovement enemyMovement)
        {
            return new RepeatNode(new SequenceNode(new IBehaviorNode[]
            {
                new IsNearNode(enemyMovement.Transform, _characterTransform, 50),
                new MoveNode(new MovementToTarget(enemyMovement, _characterTransform), new IsNearNode(enemyMovement.Transform, _characterTransform, 1.2f)),
                new AttackHealthNode(_characterHealth, 10)
            }));
        }
    }
}
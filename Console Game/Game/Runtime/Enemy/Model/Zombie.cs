using System;
using BananaParty.BehaviorTree;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class Zombie : IEnemy, IGameObject
    {
        private readonly IBehaviorNode _behaviorTree;
        
        public Zombie(IHealth health, IMovement movement, IReadOnlyCharacter character)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));

            _behaviorTree = new RepeatNode(new SequenceNode(new IBehaviorNode[]
            {
                new IsNearNode(movement.Transform, character.Transform, 50),
                new MoveNode(new MovementToTarget(movement, character.Transform), new IsNearNode(movement.Transform, character.Transform, 1.2f)),
                new AttackHealthNode(character.Health, 10)
            }));
        }

        public IHealth Health { get; }

        public bool IsAlive => Health.IsAlive;

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"Enemy is not alive! You can't update it!");

            _behaviorTree.Execute(deltaTime);

            if (_behaviorTree.IsFinished())
                _behaviorTree.Reset();
        }
    }
}
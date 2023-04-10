using System;
using BananaParty.BehaviorTree;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class ShooterEnemy : IEnemy, IGameObject
    {
        private readonly IBehaviorNode _behaviorTree;

        public ShooterEnemy(IHealth health, IMovement movement, IWeapon weapon, IReadOnlyCharacter character)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            IBehaviorNode isNearCharacterNode = new IsNearNode(character.Transform, movement.Transform, 20);

            _behaviorTree = new RepeatNode(new SequenceNode(new IBehaviorNode[]
            {
                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new RepeatNode(new SequenceNode(new IBehaviorNode[]
                    {
                        isNearCharacterNode,
                        new WaitNode(1.5f),
                        new WeaponAttackNode(weapon),
                    })),

                    new RepeatNode(new SequenceNode(new IBehaviorNode[]
                    {
                        new MoveNode(new MovementToTarget(movement, character.Transform), nodeForComplete: isNearCharacterNode),
                    }))
                })
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
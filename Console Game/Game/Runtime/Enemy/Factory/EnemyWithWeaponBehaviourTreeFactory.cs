using System;
using BananaParty.BehaviorTree;
using ConsoleGame.Weapon;

namespace ConsoleGame
{
    public sealed class EnemyWithWeaponBehaviourTreeFactory : IEnemyBehaviourTreeFactory
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly IReadOnlyTransform _character;

        public EnemyWithWeaponBehaviourTreeFactory(IWeaponFactory weaponFactory, IReadOnlyTransform character)
        {
            _weaponFactory = weaponFactory ?? throw new ArgumentNullException(nameof(weaponFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public IBehaviorNode Create(IMovement enemyMovement)
        {
            IBehaviorNode isNearCharacterNode =
                new IsNearNode(_character, enemyMovement.Transform, 20);

            return new RepeatNode(
                new SequenceNode(new IBehaviorNode[]
                {
                    new ParallelSequenceNode(new IBehaviorNode[]
                    {
                        new RepeatNode(new SelectorNode(new IBehaviorNode[]
                        {
                            isNearCharacterNode,
                            new WaitNode(1.5f),
                            new WeaponAttackNode(_weaponFactory.Create(new EnemyAim(enemyMovement.Transform, _character), new WeaponsData())),
                        })),

                        new RepeatNode(new SelectorNode(new IBehaviorNode[]
                        {
                            new MoveNode(new MovementToTarget(enemyMovement, _character),
                                nodeForComplete: isNearCharacterNode),
                        }))
                    })
                }));
        }
    }
}
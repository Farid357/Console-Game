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

            IAim aim = new EnemyAim(enemyMovement.Transform, _character);
            IWeapon weapon = _weaponFactory.Create(aim, new WeaponsData());

            return new RepeatNode(
                new SequenceNode(new IBehaviorNode[]
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
                            new MoveNode(new MovementToTarget(enemyMovement, _character),
                                nodeForComplete: isNearCharacterNode),
                        }))
                    })
                }));
        }
    }
}
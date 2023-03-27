using System;
using System.Numerics;

namespace ConsoleGame
{
    public sealed class EnemyWithMovement : IEnemyWithMovement, IGameObject
    {
        private readonly IEnemy _enemy;
        private readonly ITransform _target;

        public EnemyWithMovement(IEnemy enemy, ITransform target, IAdjustableMovement movement)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _target = target ?? throw new ArgumentNullException(nameof(target));
            Movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public bool IsAlive => _enemy.IsAlive;

        public IHealth Health => _enemy.Health;

        public IAdjustableMovement Movement { get; }

        public void Update(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception();

            Vector3 moveDirection = Vector3.Normalize(_target.Position - Movement.Transform.Position);
            Movement.Move(moveDirection);
        }
    }
}
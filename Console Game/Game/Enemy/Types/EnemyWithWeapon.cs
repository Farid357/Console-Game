using System;
using System.Numerics;
using Console_Game.Tools.Extensions;

namespace Console_Game
{
    public sealed class EnemyWithWeapon : IEnemy, IGameLoopObject
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponInput _weaponInput;
        private readonly IEnemy _enemy;

        public EnemyWithWeapon(IWeapon weapon, IWeaponInput weaponInput, IEnemy enemy)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public IHealth Health => _enemy.Health;

        public IEnemyMovement Movement => _enemy.Movement;

        public IEnemyData Data => _enemy.Data;

        public void Update(float deltaTime)
        {
            if (_weaponInput.IsUsing && _weapon.CanShoot)
                _weapon.Shoot();
        }
    }

    public interface IEnemyFactory
    {
        IEnemy Create(Vector2 position);
    }

    public sealed class EnemyWithRewardFactory : IEnemyFactory
    {
        private readonly IReward _reward;
        private readonly IEnemyFactory _enemyFactory;

        public EnemyWithRewardFactory(IReward reward, IEnemyFactory enemyFactory)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
        }

        public IEnemy Create(Vector2 position)
        {
            return new EnemyWithReward(_reward, _enemyFactory.Create(position));
        }
    }

    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly int _healthCount;
        private readonly IEnemyData _data;

        public EnemyFactory(int healthCount, IEnemyData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _healthCount = healthCount.ThrowIfLessThanOrEqualsToZeroException();
        }

        public IEnemy Create(Vector2 position)
        {
            IEnemyMovement movement = new EnemyMovement(position, new EnemyMovementView());
            movement.TeleportTo(position);
            IHealth health = new Health(new HealthView(), _healthCount);
            return new Enemy(health, movement, _data);
        }
    }
}
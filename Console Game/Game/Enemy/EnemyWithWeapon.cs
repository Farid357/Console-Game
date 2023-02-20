using System;
using System.Numerics;

namespace Console_Game
{
    public sealed class EnemyWithWeapon : IUpdateable
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponInput _weaponInput;

        public EnemyWithWeapon(IWeapon weapon, IWeaponInput weaponInput)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
        }
        
        public void Update(float deltaTime)
        {
            if (_weaponInput.IsUsing && _weapon.CanShoot)
                _weapon.Shoot();
        }

    }

    public sealed class EnemyWithReward : IUpdateable
    {
        private readonly IReward _reward;
        private readonly IEnemy _enemy;

        public EnemyWithReward(IReward reward, IEnemy enemy)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public void Update(float deltaTime)
        {
            if(_enemy.Health.IsDied && _reward.IsApplied == false)
                _reward.Apply();
        }
    }

    public sealed class Enemy : IEnemy
    {
        public Enemy(IHealth health, Vector2 position)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Position = position;
        }

        public IHealth Health { get; }
        
        public Vector2 Position { get; }
    }
}
using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class EnemyWithWeapon : IEnemy, IGameLoopObject
    {
        private readonly IWeaponWithMagazine _weapon;
        private readonly IWeaponInput _weaponInput;
        private readonly IEnemy _enemy;
        private readonly ITimer _reloadTimer;
        
        public EnemyWithWeapon(IWeaponWithMagazine weapon, IWeaponInput weaponInput, IEnemy enemy, ITimer reloadTimer)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _weaponInput = weaponInput ?? throw new ArgumentNullException(nameof(weaponInput));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _reloadTimer = reloadTimer ?? throw new ArgumentNullException(nameof(reloadTimer));
        }

        public IHealth Health => _enemy.Health;

        public IMovement Movement => _enemy.Movement;

        public IEnemyData Data => _enemy.Data;

        public void Update(long deltaTime)
        {
            if (_weaponInput.IsUsing && _weapon.CanShoot)
            {
                _weapon.Shoot();
            }

            if (_weapon.Magazine.IsEmpty)
            {
                _reloadTimer.Play();
                _weapon.Magazine.Reload();
            }
        }
    }
}
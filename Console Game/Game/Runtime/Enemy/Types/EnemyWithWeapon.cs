using System;
using System.Threading.Tasks;
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

        public void Update(float deltaTime) => TryShoot();

        private async Task TryReload()
        {
            if (!_weapon.Magazine.IsEmpty)
                return;

            if (_reloadTimer.Time > 0f)
                _reloadTimer.ResetTime();


            while (!_reloadTimer.IsEnded)
                await Task.Yield();

            await _weapon.Reload();
        }

        private async void TryShoot()
        {
            if (_weaponInput.IsUsing && _weapon.CanShoot)
            {
                _weapon.Shoot();
            }

            await TryReload();
        }
    }
}
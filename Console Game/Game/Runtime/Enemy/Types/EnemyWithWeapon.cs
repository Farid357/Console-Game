using System;
using System.Threading.Tasks;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class EnemyWithWeapon : IEnemy, IGameLoopObject
    {
        private readonly IWeaponWithMagazine _weapon;
        private readonly ITimer _attackTimer;
        private readonly IEnemy _enemy;
        private readonly ITimer _reloadTimer;

        public EnemyWithWeapon(IWeaponWithMagazine weapon, ITimer attackTimer, IEnemy enemy, ITimer reloadTimer)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            _attackTimer = attackTimer ?? throw new ArgumentNullException(nameof(attackTimer));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _reloadTimer = reloadTimer ?? throw new ArgumentNullException(nameof(reloadTimer));
        }

        public IHealth Health => _enemy.Health;

        public bool IsAlive => _enemy.IsAlive;
        
        public void Update(float deltaTime) => TryShoot();

        private async Task TryReload()
        {
            if (_weapon.Magazine.Bullets > 0)
                return;

            if (_reloadTimer.Time > 0f)
                _reloadTimer.ResetTime();
            
            while (!_reloadTimer.IsEnded)
                await Task.Yield();

            await _weapon.Reload();
        }

        private async void TryShoot()
        {
            if (_attackTimer.IsEnded && _weapon.CanShoot)
            {
                _attackTimer.ResetTime();
                _weapon.Shoot();
            }

            await TryReload();
        }

    }
}
using System;
using ConsoleGame;
using ConsoleGame.Weapons;

namespace Console_Game
{
    public sealed class WeaponWithBattery : IWeapon
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IAim _aim;
        private readonly IBattery _battery;
        private readonly IWeaponView _view;

        public WeaponWithBattery(IBulletFactory bulletFactory, IAim aim, IBattery battery, IWeaponView view)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _aim = aim ?? throw new ArgumentNullException(nameof(aim));
            _battery = battery ?? throw new ArgumentNullException(nameof(battery));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public IWeaponActivityView View => _view;
        
        public bool CanShoot => View.IsActive;

        public void Shoot()
        {
            if (CanShoot == false)
                throw new Exception($"View is not active, you can't shoot!");
            
            float damage = _battery.IsDischarged ? 10 : _battery.Amount * 100;
            IBullet bullet = _bulletFactory.Create((int)damage);
            bullet.Throw(_aim.Target);
            _view.Shoot();
        }
    }
}
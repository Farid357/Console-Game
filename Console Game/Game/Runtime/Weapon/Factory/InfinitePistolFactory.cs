using System;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class InfinitePistolFactory : IWeaponFactory
    {
        private readonly IInfiniteBulletsViewFactory _viewFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly ITimerFactory _timerFactory;
        
        public InfinitePistolFactory(ITimerFactory timerFactory, IInfiniteBulletsViewFactory viewFactory, IBulletFactory bulletFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _timerFactory = timerFactory ?? throw new ArgumentNullException(nameof(timerFactory));
        }

        public IWeapon Create()
        {
            IInfiniteBulletsView view = _viewFactory.Create();
            ITimer cooldownTimer = _timerFactory.Create(0.4f);
            return new WeaponWithInfiniteBullets(
                new WeaponWithShootWaiting(cooldownTimer, new Weapon(_bulletFactory, 10)), view);
        }
    }
}
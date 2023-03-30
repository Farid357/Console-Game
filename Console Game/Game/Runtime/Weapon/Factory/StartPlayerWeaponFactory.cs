using System;
using ConsoleGame.GameLoop;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class StartPlayerWeaponFactory : IWeaponWithMagazineFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWeaponMagazineFactory _magazineFactory;
        private readonly IBulletFactory _bulletFactory;

        public StartPlayerWeaponFactory(IGameLoopObjectsGroup gameLoop, IWeaponMagazineFactory magazineFactory, IBulletFactory bulletFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _magazineFactory = magazineFactory ?? throw new ArgumentNullException(nameof(magazineFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
        }

        public IWeaponWithMagazine Create()
        {
            IWeaponMagazine magazine = _magazineFactory.Create();
            var shootCooldownTimer = new Timer(0.2f);
            IWeapon weapon = new Weapon(_bulletFactory, 10);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(shootCooldownTimer, weapon);
            _gameLoop.Add(shootCooldownTimer);
            IWeaponWithMagazineView view = new WeaponWithMagazineView();
            return new WeaponWithMagazine(magazine, weaponWithShootWaiting, view);
        }
    }
}
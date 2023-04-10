using System;
using Console_Game;
using ConsoleGame.GameLoop;
using ConsoleGame.Tests.UI;
using ConsoleGame;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponWithMagazineFactory : IWeaponFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWeaponMagazineFactory _magazineFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly IWeaponViewFactory _viewFactory;

        public WeaponWithMagazineFactory(IGameLoopObjectsGroup gameLoop, IWeaponMagazineFactory magazineFactory,
            IBulletFactory bulletFactory, IWeaponViewFactory viewFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _magazineFactory = magazineFactory ?? throw new ArgumentNullException(nameof(magazineFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public (IWeapon Weapon, IWeaponPartsData PartsData) Create(IAim aim)
        {
            IWeaponMagazine magazine = _magazineFactory.Create();
            var shootCooldownTimer = new Timer(0.2f);
            IWeaponView weaponView = _viewFactory.Create(new DummyImage());
            IWeaponPartsData partsData = new WeaponPartsData(false, shootCooldownTimer, new NullBattery(), magazine);
            IWeapon weapon = new Weapon(_bulletFactory, aim, weaponView, 10);
            IWeapon weaponWithShootWaiting = new WeaponWithRateOfShot(weapon, shootCooldownTimer);
            IWeapon weaponWithMagazine = new WeaponWithMagazine(weaponWithShootWaiting, magazine);
            _gameLoop.Add(shootCooldownTimer);
            return (weaponWithMagazine, partsData);
        }
    }
}
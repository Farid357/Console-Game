using System;
using Console_Game;
using ConsoleGame.GameLoop;
using ConsoleGame.Tests.UI;
using ConsoleGame.Weapon;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class StartWeaponFactory : IWeaponFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWeaponMagazineFactory _magazineFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly IWeaponViewFactory _viewFactory;

        public StartWeaponFactory(IGameLoopObjectsGroup gameLoop, IWeaponMagazineFactory magazineFactory,
            IBulletFactory bulletFactory, IWeaponViewFactory viewFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _magazineFactory = magazineFactory ?? throw new ArgumentNullException(nameof(magazineFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IWeapon Create(IAim aim, IWeaponsData weaponsData)
        {
            IWeaponMagazine magazine = _magazineFactory.Create();
            var shootCooldownTimer = new Timer(0.2f);
            IWeaponView weaponView = _viewFactory.Create(new DummyImage());
            IWeaponData weaponData = new WeaponData(false, shootCooldownTimer, new NullBattery(), magazine);
            IWeapon weapon = new Weapons.Weapon(_bulletFactory, aim, weaponView, 10);
            IWeapon weaponWithShootWaiting = new WeaponWithRateOfShot(weapon, shootCooldownTimer);
            IWeapon weaponWithMagazine = new WeaponWithMagazine(weaponWithShootWaiting, magazine);
            _gameLoop.Add(shootCooldownTimer);
            weaponsData.Add(weaponWithMagazine, weaponData);
            return weaponWithMagazine;
        }
    }
}
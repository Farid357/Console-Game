using System;
using Console_Game;
using ConsoleGame.GameLoop;
using ConsoleGame.Tests.UI;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class StartWeaponFactory : IWeaponFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IWeaponMagazineFactory _magazineFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly IReadOnlyMovement _movement;
        private readonly IWeaponViewFactory _viewFactory;

        public StartWeaponFactory(IGameLoopObjectsGroup gameLoop, IWeaponMagazineFactory magazineFactory,
            IBulletFactory bulletFactory, IReadOnlyMovement movement, IWeaponViewFactory viewFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _magazineFactory = magazineFactory ?? throw new ArgumentNullException(nameof(magazineFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IWeapon Create()
        {
            IWeaponMagazine magazine = _magazineFactory.Create();
            var shootCooldownTimer = new Timer(0.2f);
            IWeaponView view = _viewFactory.Create(new DummyImage());
            IWeaponData weaponData = new WeaponData(false, 10, shootCooldownTimer, magazine, view, new NullBattery());
            IWeapon weapon = new CharacterWeapon(_bulletFactory, _movement, weaponData);
            IWeapon weaponWithShootWaiting = new WeaponWithShootWaiting(weapon);
            _gameLoop.Add(shootCooldownTimer);
            return new WeaponWithMagazine(weaponWithShootWaiting);
        }
    }
}
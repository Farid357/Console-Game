using System;
using Console_Game;
using ConsoleGame.GameLoop;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class InfinitePistolFactory : IWeaponFactory
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IInfiniteWeaponViewFactory _viewFactory;
        private readonly IBulletFactory _bulletFactory;

        public InfinitePistolFactory(IGameLoopObjectsGroup gameLoop, IInfiniteWeaponViewFactory viewFactory, IBulletFactory bulletFactory)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
        }

        public (IWeapon Weapon, IWeaponPartsData PartsData) Create(IAim aim)
        {
            IInfiniteWeaponView weaponView = _viewFactory.Create();
            var cooldownTimer = new Timer(0.4f);
            IWeaponPartsData partsData = new WeaponPartsData(false, cooldownTimer, new NullBattery(), new NullWeaponMagazine());
            IWeapon characterWeapon = new Weapon(_bulletFactory, aim, weaponView, 10);
            IWeapon shootWaiting = new WeaponWithRateOfShot(characterWeapon, cooldownTimer);
            IWeapon infiniteWeapon = new InfiniteWeapon(shootWaiting, weaponView);
            _gameLoop.Add(cooldownTimer);
            return (infiniteWeapon, partsData);
        }
    }
}
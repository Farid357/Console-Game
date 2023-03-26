using System;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class InfinitePistolFactory : IFactory<IWeapon>
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IInfiniteBulletsViewFactory _viewFactory;
        private readonly IBulletFactory _bulletFactory;

        public InfinitePistolFactory(IGroup<IGameLoopObject> gameLoopObjects, IInfiniteBulletsViewFactory viewFactory, IBulletFactory bulletFactory)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
        }

        public IWeapon Create()
        {
            var cooldownTimer = new Timer(0.2f);
            _gameLoopObjects.Add(cooldownTimer);
            IInfiniteBulletsView view = _viewFactory.Create();
            return new WeaponWithInfiniteBullets(
                new WeaponWithShootWaiting(cooldownTimer, new Weapon(_bulletFactory, 10)), view);
        }
    }
}
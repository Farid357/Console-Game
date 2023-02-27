using System;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class InfinitePistolFactory : IFactory<IWeapon>
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IBulletsFactory _bulletsFactory;

        public InfinitePistolFactory(IGroup<IGameLoopObject> gameLoopObjects)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _bulletsFactory = new BulletsFactory(new ReadOnlyTransform());
        }

        public IWeapon Create()
        {
            var cooldownTimer = new Timer(0.2f);
            _gameLoopObjects.Add(cooldownTimer);
            return new WeaponWithShootWaiting(cooldownTimer, new Weapon(_bulletsFactory));
        }
    }
}
using System;
using Console_Game.UI;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class InfinitePistolFactory : IFactory<IWeapon>
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IText _text;
        private readonly IBulletsFactory _bulletsFactory;

        public InfinitePistolFactory(IGroup<IGameLoopObject> gameLoopObjects, IText text, IBulletsFactory bulletsFactory)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _bulletsFactory = bulletsFactory ?? throw new ArgumentNullException(nameof(bulletsFactory));
        }

        public IWeapon Create()
        {
            var cooldownTimer = new Timer(0.2f);
            _gameLoopObjects.Add(cooldownTimer);
            IInfiniteBulletsView infiniteBulletsView = new InfiniteBulletsView(_text);
            return new WeaponWithInfiniteBullets(new WeaponWithShootWaiting(cooldownTimer, new Weapon(_bulletsFactory, 10)),
                infiniteBulletsView);
        }
    }
}
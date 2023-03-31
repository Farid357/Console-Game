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
        private readonly IReadOnlyCharacter _character;

        public InfinitePistolFactory(IGameLoopObjectsGroup gameLoop, IInfiniteWeaponViewFactory viewFactory, IBulletFactory bulletFactory, IReadOnlyCharacter character)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public IWeapon Create()
        {
            IInfiniteWeaponView view = _viewFactory.Create();
            var cooldownTimer = new Timer(0.4f);
            IWeaponData data = new WeaponData(false, 10, cooldownTimer, new NullWeaponMagazine(), view, new NullBattery());
            IWeapon characterWeapon = new WeaponWithView(new CharacterWeapon(_bulletFactory, _character.Movement, data), view);
            IWeapon shootWaiting = new WeaponWithShootWaiting(characterWeapon);
            _gameLoop.Add(cooldownTimer);
            return new InfiniteWeapon(shootWaiting, view);
        }
    }
}
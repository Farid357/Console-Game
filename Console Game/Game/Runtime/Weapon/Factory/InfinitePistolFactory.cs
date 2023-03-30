using System;
using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class InfinitePistolFactory : IWeaponFactory
    {
        private readonly IInfiniteWeaponViewFactory _viewFactory;
        private readonly IBulletFactory _bulletFactory;
        private readonly IReadOnlyCharacter _character;
        private readonly ITimerFactory _timerFactory;
        
        public InfinitePistolFactory(ITimerFactory timerFactory, IInfiniteWeaponViewFactory viewFactory, IBulletFactory bulletFactory, IReadOnlyCharacter character)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _timerFactory = timerFactory ?? throw new ArgumentNullException(nameof(timerFactory));
        }

        public IWeapon Create()
        {
            IInfiniteWeaponView view = _viewFactory.Create();
            ITimer cooldownTimer = _timerFactory.Create(0.4f);
            IWeapon shootWaiting = new WeaponWithShootWaiting(cooldownTimer, new CharacterWeapon(_bulletFactory, _character.Movement, 10));
            return new InfiniteWeapon(shootWaiting, view);
        }
    }
}
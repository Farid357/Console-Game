using System;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponMagazineFactory : IWeaponMagazineFactory
    {
        private readonly IWeaponMagazineViewFactory _viewFactory;
        private readonly int _bullets;

        public WeaponMagazineFactory(IWeaponMagazineViewFactory viewFactory, int bullets)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _bullets = bullets;
        }

        public IWeaponMagazine Create()
        {
            IWeaponMagazineView view = _viewFactory.Create();
            return new WeaponMagazine(_bullets, view);
        }
    }
}
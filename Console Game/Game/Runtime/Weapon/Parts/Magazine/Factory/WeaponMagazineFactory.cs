using System;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponMagazineFactory : IWeaponMagazineFactory
    {
        private readonly IWeaponMagazineView _view;
        private readonly int _bullets;

        public WeaponMagazineFactory(IWeaponMagazineView view, int bullets)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _bullets = bullets;
        }

        public IWeaponMagazine Create()
        {
            return new WeaponMagazine(_bullets, _view);
        }
    }
}
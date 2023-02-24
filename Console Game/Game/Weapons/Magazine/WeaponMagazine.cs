using System;
using Console_Game.Tools;

namespace Console_Game.Weapons
{
    public sealed class WeaponMagazine : IWeaponMagazine
    {
        private readonly IWeaponMagazineView _magazineView;

        public WeaponMagazine(int bullets, IWeaponMagazineView magazineView)
        {
            _magazineView = magazineView ?? throw new ArgumentNullException(nameof(magazineView));
            Bullets = bullets.ThrowIfLessThanOrEqualsToZeroException();
            MaxBullets = Bullets;
        }

        public int Bullets { get; private set; }

        public int MaxBullets { get; }

        public bool IsEmpty => Bullets == 0;

        public bool CanAdd(int bullets) => Bullets + bullets <= MaxBullets;

        public void Take(int bullets)
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Can't take bullet, magazine is empty!");

            Bullets -= bullets.ThrowIfLessThanOrEqualsToZeroException();
            _magazineView.Visualize(Bullets, MaxBullets);
        }

        public void Add(int bullets)
        {
            if (CanAdd(bullets) == false)
                throw new InvalidOperationException(nameof(Add));

            Bullets += bullets.ThrowIfLessThanOrEqualsToZeroException();
            _magazineView.Visualize(Bullets, MaxBullets);
        }
    }
}
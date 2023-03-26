using System;
using ConsoleGame.Tools;

namespace ConsoleGame.Weapons
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
        
        public int MaxBullets { get; }

        public int Bullets { get; private set; }

        public bool IsEmpty => Bullets == 0;

        public void Take(int bullets)
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Can't take bullet, magazine is empty!");

            if (Bullets - bullets < 0)
                throw new ArgumentOutOfRangeException($"Too large bullets: {bullets}");
            
            Bullets -= bullets.ThrowIfLessThanOrEqualsToZeroException();
            _magazineView.Visualize(Bullets, MaxBullets);
        }

        public void Add(int bullets)
        {
            if (Bullets + bullets > MaxBullets)
                throw new InvalidOperationException(nameof(Add));

            Bullets += bullets.ThrowIfLessThanOrEqualsToZeroException();
            _magazineView.Visualize(Bullets, MaxBullets);
        }
    }
}
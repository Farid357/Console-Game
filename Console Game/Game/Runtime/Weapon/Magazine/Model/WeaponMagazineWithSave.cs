using System;
using Console_Game.Save_Storages;

namespace Console_Game.Weapons
{
    public class WeaponMagazineWithSave : IWeaponMagazine
    {
        private readonly IWeaponMagazine _magazine;
        private readonly ISaveStorage<int> _bullets;

        public WeaponMagazineWithSave(IWeaponMagazine magazine, ISaveStorage<int> bulletsStorage)
        {
            _magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
            _bullets = bulletsStorage ?? throw new ArgumentNullException(nameof(bulletsStorage));
        }

        public int Bullets => _magazine.Bullets;

        public int MaxBullets => _magazine.MaxBullets;

        public bool IsEmpty => _magazine.IsEmpty;

        public bool CanAdd(int bullets) => _magazine.CanAdd(bullets);

        public void Take(int bullets)
        {
            _magazine.Take(bullets);
        }

        public void Add(int bullets)
        {
            _magazine.Add(bullets);
        }
    }
}
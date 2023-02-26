using System;

namespace Console_Game.Weapons
{
    public interface IWeaponMagazine : IReadOnlyWeaponMagazine
    {
        void Take(int bullets);

        void Add(int bullets);

        void Reload();
    }

    //Is it right?
    public sealed class WeaponInfiniteMagazine : IWeaponMagazine
    {
        public int Bullets => int.MaxValue;

        public int MaxBullets => int.MaxValue;

        public bool IsEmpty => false;
        
        public bool CanAdd(int bullets) => false;
        

        public void Take(int bullets)
        {
            
        }

        public void Add(int bullets)
        {
            
        }

        public void Reload()
        {
        }
    }
}
using System;
using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public struct WeaponData : IWeaponData
    {
        public WeaponData(bool isBurst, ITimer rateOfShootTimer = null, IBattery battery = null, IWeaponMagazine magazine = null)
        {
            IsBurst = isBurst;
            RateOfShootTimer = rateOfShootTimer ?? new Timer(0.3f);
            Magazine = magazine ?? new NullWeaponMagazine();
            Battery = battery ?? new NullBattery();
        }

        public bool IsBurst { get; }
        
        public ITimer RateOfShootTimer { get; }
        
        public IWeaponMagazine Magazine { get; }
        
        public IBattery Battery { get; }
    }
}
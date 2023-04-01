using System;
using Console_Game;
using ConsoleGame.Tools;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public struct WeaponData : IWeaponData
    {
        public WeaponData(bool isBurst, ITimer cooldownTimer, IBattery battery = null, IWeaponMagazine magazine = null)
        {
            IsBurst = isBurst;
            CooldownTimer = cooldownTimer ?? throw new ArgumentNullException(nameof(cooldownTimer));
            Magazine = magazine ?? new NullWeaponMagazine();
            Battery = battery ?? new NullBattery();
        }

        public bool IsBurst { get; }
        
        public ITimer CooldownTimer { get; }
        
        public IWeaponMagazine Magazine { get; }
        
        public IBattery Battery { get; }
    }
}
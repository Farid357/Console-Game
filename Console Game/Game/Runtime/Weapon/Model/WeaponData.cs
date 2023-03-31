using System;
using Console_Game;
using ConsoleGame.Tools;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public struct WeaponData : IWeaponData
    {
        public WeaponData(bool isBurst, int damage, ITimer cooldownTimer, IWeaponMagazine magazine, IWeaponActiveView view, IBattery battery)
        {
            IsBurst = isBurst;
            Damage = damage.ThrowIfLessThanZeroException();
            CooldownTimer = cooldownTimer ?? throw new ArgumentNullException(nameof(cooldownTimer));
            Magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
            View = view ?? throw new ArgumentNullException(nameof(view));
            Battery = battery ?? throw new ArgumentNullException(nameof(battery));
        }

        public bool IsBurst { get; }
        
        public int Damage { get; }
        
        public ITimer CooldownTimer { get; }
        
        public IWeaponMagazine Magazine { get; }
        
        public IWeaponActiveView View { get; }
        
        public IBattery Battery { get; }
    }
}
using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class WeaponParts : IWeaponParts
    {
        public WeaponParts(bool isBurst, ITimer rateOfShootTimer = null, IBattery battery = null, IWeaponMagazine magazine = null)
        {
            IsBurst = isBurst;
            RateOfShootTimer = rateOfShootTimer ?? new Timer(0.3f);
            Magazine = magazine ?? new NullWeaponMagazine();
            Battery = battery;
            
            if (Battery == null)
            {
                Battery = new NullBattery();
            }
            
            else
            {
                CanChargeBattery = true;
            }
        }

        public bool IsBurst { get; }
        
        public bool CanChargeBattery { get; }

        public ITimer RateOfShootTimer { get; }
        
        public IWeaponMagazine Magazine { get; }
        
        public IBattery Battery { get; }
    }
}
using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponParts
    {
        bool IsBurst { get; }
        
        bool BatteryIsChargeable { get; }
        
        ITimer RateOfShootTimer { get; }
        
        IWeaponMagazine Magazine { get; }
        
        IBattery Battery { get; }
    }
}
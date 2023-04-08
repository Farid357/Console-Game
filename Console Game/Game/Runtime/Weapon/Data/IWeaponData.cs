using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponData
    {
        bool IsBurst { get; }
        
        bool CanChargeBattery { get; }
        
        ITimer RateOfShootTimer { get; }
        
        IWeaponMagazine Magazine { get; }
        
        IBattery Battery { get; }
    }
}
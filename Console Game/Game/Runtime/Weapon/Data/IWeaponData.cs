using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponData
    {
        bool IsBurst { get; }
        
        ITimer CooldownTimer { get; }
        
        IWeaponMagazine Magazine { get; }
        
        IBattery Battery { get; }
    }
}
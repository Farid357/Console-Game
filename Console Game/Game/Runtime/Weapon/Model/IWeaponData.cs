using Console_Game;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponData
    {
        bool IsBurst { get; }
        
        int Damage { get; }
        
        ITimer CooldownTimer { get; }
        
        IWeaponMagazine Magazine { get; }
        
        IWeaponActiveView View { get; }
        
        IBattery Battery { get; }
    }
}
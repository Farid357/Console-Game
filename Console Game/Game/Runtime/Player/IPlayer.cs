using Console_Game.Weapons;

namespace Console_Game
{
    public interface IPlayer
    {
        IWeaponInput WeaponInput { get; }
        
        IWeaponWithMagazine Weapon { get; }
    }
}
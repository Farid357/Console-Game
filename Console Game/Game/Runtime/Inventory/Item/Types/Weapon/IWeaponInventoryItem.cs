using Console_Game.Weapons;

namespace Console_Game
{
    public interface IWeaponInventoryItem : IInventoryItem
    {
        IWeaponWithMagazine Weapon { get; }
        
        IWeaponInput WeaponInput { get; }
    }
}
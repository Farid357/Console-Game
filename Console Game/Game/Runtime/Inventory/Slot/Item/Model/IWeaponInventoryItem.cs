namespace ConsoleGame
{
    public interface IWeaponInventoryItem : IInventoryItem
    {
        IWeapon Weapon { get; }
        
        IWeaponParts WeaponParts { get; }
        
    }
}
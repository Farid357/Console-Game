namespace ConsoleGame
{
    public interface IWeaponInventoryItem : IInventoryItem
    {
        IWeapon Weapon { get; }
        
        IWeaponPartsData WeaponPartsData { get; }
        
    }
}
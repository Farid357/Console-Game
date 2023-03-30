namespace ConsoleGame
{
    public interface IWeaponInventoryItem<out TWeapon> : IInventoryItem
    {
        TWeapon Weapon { get; }
    }
}
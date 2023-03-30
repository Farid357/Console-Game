namespace ConsoleGame
{
    public interface IWeaponInventoryItem<out TWeapon> : IInventoryItem where TWeapon : IWeapon
    {
        TWeapon Weapon { get; }
    }
}
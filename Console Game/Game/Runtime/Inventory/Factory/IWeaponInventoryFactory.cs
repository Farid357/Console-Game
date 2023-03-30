using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponInventoryFactory
    {
        IInventory<IWeaponInventoryItem<IWeapon>> CreateStandard();

        IInventory<IWeaponInventoryItem<IWeaponWithMagazine>> CreateWithMagazine();
    }
}
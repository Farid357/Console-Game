using Console_Game.Weapons;

namespace Console_Game.Inventory.Factory
{
    public interface IWeaponInventoryFactory
    {
        IInventory<IWeaponInventoryItem<IWeaponInput, IWeapon>> CreateStandard();

        IInventory<IWeaponInventoryItem<IWeaponInput, IWeaponWithMagazine>> CreateWithMagazine();
    }
}
namespace ConsoleGame
{
    public interface IWeaponInventoryFactory
    {
        IInventory<IWeaponInventoryItem> CreateStandard();

        IInventory<IWeaponInventoryItem> CreateWithMagazine();
    }
}
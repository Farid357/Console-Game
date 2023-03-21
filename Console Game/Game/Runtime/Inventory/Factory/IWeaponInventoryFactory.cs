namespace Console_Game
{
    public interface IWeaponInventoryFactory
    {
        IInventory<IWeaponInventoryItem> CreateStandard();

        IInventory<IWeaponInventoryItem> CreateWithMagazine();
    }
}
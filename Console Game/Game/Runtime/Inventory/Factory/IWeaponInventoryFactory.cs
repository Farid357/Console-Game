namespace ConsoleGame
{
    public interface IWeaponInventoryFactory
    {
        IInventory<IWeaponInventoryItem> Create();
    }
}
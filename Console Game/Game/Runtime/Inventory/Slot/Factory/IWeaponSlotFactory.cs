namespace ConsoleGame
{
    public interface IWeaponSlotFactory
    {
        IInventorySlot<IWeaponInventoryItem> Create(IInventoryItemViewData viewData, IWeapon weapon, IWeaponParts weaponParts);
    }
}
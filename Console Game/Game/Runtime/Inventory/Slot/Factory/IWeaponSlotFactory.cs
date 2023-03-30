namespace ConsoleGame
{
    public interface IWeaponSlotFactory<TWeapon> where TWeapon : IWeapon
    {
        IInventorySlot<IWeaponInventoryItem<TWeapon>> Create(IInventoryItemViewData viewData, TWeapon weapon);
    }
}
namespace ConsoleGame
{
    public interface IWeaponSlotFactory<out TWeapon, in TShooter>
    {
        IInventorySlot<IWeaponInventoryItem<TWeapon>> Create(IInventoryItemViewData viewData, TShooter shooter);
    }
}
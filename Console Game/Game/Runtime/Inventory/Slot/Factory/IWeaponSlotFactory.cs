namespace Console_Game
{
    public interface IWeaponSlotFactory<in TWeapon, in TWeaponInput>
    {
        IInventorySlot<IWeaponInventoryItem> Create(IInventoryItemViewData viewData, TWeapon weapon,
            TWeaponInput weaponInput);
    }
}
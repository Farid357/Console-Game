namespace Console_Game
{
    public interface IWeaponSlotFactory<in TWeapon, in TWeaponInput>
    {
        IInventorySlot<IWeaponInventoryItem> Create(string name, TWeapon weapon, TWeaponInput weaponInput);
    }
}
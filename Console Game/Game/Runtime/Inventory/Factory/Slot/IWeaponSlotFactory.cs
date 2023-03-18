namespace Console_Game
{
    public interface IWeaponSlotFactory
    {
        IInventorySlot<IWeaponInventoryItem<IWeaponInput, IWeapon>> Create(string name, IWeapon weapon, IWeaponInput weaponInput);
    }
}
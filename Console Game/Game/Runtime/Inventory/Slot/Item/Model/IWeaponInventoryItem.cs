namespace Console_Game
{
    public interface IWeaponInventoryItem : IInventoryItem
    {
        IWeapon Weapon { get; }
    }
}
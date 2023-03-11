namespace Console_Game
{
    public interface IWeaponInventoryItem<out TWeaponInput, out TWeapon> : IInventoryItem
        where TWeaponInput : IWeaponInput where TWeapon : IWeapon
    {
        TWeapon Weapon { get; }

        TWeaponInput WeaponInput { get; }
    }
}
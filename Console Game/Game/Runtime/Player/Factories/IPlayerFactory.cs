namespace ConsoleGame
{
    public interface IPlayerFactory<in TWeapon, in TWeaponInput, out TPlayer> where TWeapon : IWeapon where TWeaponInput : IWeaponInput
    {
        TPlayer Create(TWeaponInput weaponInput, TWeapon weapon);
    }
}
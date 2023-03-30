namespace ConsoleGame
{
    public interface IShooterFactory<in TWeapon, in TWeaponInput, out TPlayer>
    {
        TPlayer Create(TWeaponInput weaponInput, TWeapon weapon);
    }
}
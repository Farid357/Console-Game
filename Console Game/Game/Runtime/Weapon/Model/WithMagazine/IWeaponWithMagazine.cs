namespace ConsoleGame.Weapons
{
    public interface IWeaponWithMagazine : IWeapon
    {
        IWeaponMagazine Magazine { get; }

    }
}
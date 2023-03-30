using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class ShooterWithWeaponMagazineFactory : IShooterFactory<IWeaponWithMagazine, IWeaponInput, IShooterWithWeaponMagazine>
    {
        public IShooterWithWeaponMagazine Create(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            IShooterWithWeaponMagazine shooter = new ShooterWithWeaponMagazine(weaponInput, weapon);
            return shooter;
        }
    }
}
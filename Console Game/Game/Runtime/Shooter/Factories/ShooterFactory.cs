namespace ConsoleGame
{
    public sealed class ShooterFactory : IShooterFactory<IWeapon, IWeaponInput, IShooter<IWeapon>>
    {
        public IShooter<IWeapon> Create(IWeaponInput weaponInput, IWeapon weapon)
        {
            IShooter<IWeapon> shooter = new Shooter(weaponInput, weapon);
            return shooter;
        }
    }
}
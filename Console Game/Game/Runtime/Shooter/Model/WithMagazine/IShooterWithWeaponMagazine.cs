using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IShooterWithWeaponMagazine : IShooter<IWeaponWithMagazine>
    {
    }
}
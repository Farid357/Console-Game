using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponWithMagazineFactory
    {
        IWeaponWithMagazine Create();
    }
}
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponMagazineFactory
    {
        IWeaponMagazine Create();
    }
}
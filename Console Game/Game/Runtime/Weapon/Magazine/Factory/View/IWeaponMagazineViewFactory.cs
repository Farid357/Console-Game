using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IWeaponMagazineViewFactory
    {
        IWeaponMagazineView Create();
    }
}
using ConsoleGame.Weapon;

namespace ConsoleGame
{
    public interface IWeaponFactory
    {
        IWeapon Create(IAim aim, IWeaponsData weaponsData);
    }
}
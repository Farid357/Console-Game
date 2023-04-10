namespace ConsoleGame.Weapons
{
    public interface IWeaponFactory
    {
        (IWeapon Weapon, IWeaponParts PartsData) Create(IAim aim);
    }
}
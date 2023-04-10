namespace ConsoleGame.Weapons
{
    public interface IWeaponFactory
    {
        (IWeapon Weapon, IWeaponPartsData PartsData) Create(IAim aim);
    }
}
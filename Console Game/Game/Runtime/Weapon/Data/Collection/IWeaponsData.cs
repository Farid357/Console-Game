namespace ConsoleGame.Weapon
{
    public interface IWeaponsData
    {
        IWeaponData DataFor(IWeapon weapon);
        
        void Add(IWeapon weapon, IWeaponData data);
    }
}
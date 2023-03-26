namespace ConsoleGame
{
    public interface IReadOnlyPlayer
    {
        IWeaponInput WeaponInput { get; }
        
        IWeapon Weapon { get; }
    }
}
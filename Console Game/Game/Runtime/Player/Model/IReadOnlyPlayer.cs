namespace Console_Game
{
    public interface IReadOnlyPlayer
    {
        IWeaponInput WeaponInput { get; }
        
        IWeapon Weapon { get; }
    }
}
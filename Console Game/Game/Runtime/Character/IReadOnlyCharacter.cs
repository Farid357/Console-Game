namespace ConsoleGame
{
    public interface IReadOnlyCharacter
    {
        bool IsAlive { get; }
        
        bool CanShoot { get; }
        
        IWeaponData WeaponData { get; }
    }
}
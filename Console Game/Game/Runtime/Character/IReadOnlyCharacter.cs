namespace ConsoleGame
{
    public interface IReadOnlyCharacter
    {
        bool CanShoot { get; }
        
        IWeaponData WeaponData { get; }
        
        IHealth Health { get; }
        
        IAdjustableMovement Movement { get; }
    }
}
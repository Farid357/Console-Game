namespace ConsoleGame
{
    public interface IReadOnlyCharacter
    {
        bool CanShoot { get; }
        
        IWeapon FirstWeapon { get; }
        
        IWeapon SecondWeapon { get; }
        
        IHealth Health { get; }
        
        IAdjustableMovement Movement { get; }
    }
}
namespace ConsoleGame
{
    public interface IShooterWithTwoWeapon<out TFirstWeapon, out TSecondWeapon>
    {
        TFirstWeapon FirstWeapon { get; }
        
        TSecondWeapon SecondWeapon { get; }
    }
}
namespace ConsoleGame
{
    public interface IPlayerWithTwoWeapon : IPlayer
    {
        IWeaponInput SecondWeaponInput { get; }

        IWeapon SecondWeapon { get; }
    }
}
namespace Console_Game
{
    public interface IPlayerWithTwoWeapon : IPlayer
    {
        IWeaponInput SecondWeaponInput { get; }

        IWeapon SecondWeapon { get; }
    }
}
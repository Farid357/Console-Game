using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public interface IPlayerWithWeaponMagazine : IPlayer
    {
        IWeaponMagazine Magazine { get; }
    }
}
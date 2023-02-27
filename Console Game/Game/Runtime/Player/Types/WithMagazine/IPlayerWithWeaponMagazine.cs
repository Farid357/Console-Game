using Console_Game.Weapons;

namespace Console_Game
{
    public interface IPlayerWithWeaponMagazine : IPlayer
    {
        IWeaponMagazine Magazine { get; }
    }
}
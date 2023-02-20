using Console_Game.Weapons;

namespace Console_Game
{
    public interface IPlayerSimulation
    {
        IPlayer CreatePlayer(IWeaponInput weaponInput, IWeaponWithMagazine weapon);
    }
}
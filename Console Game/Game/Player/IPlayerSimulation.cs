using Console_Game.Weapons;

namespace Console_Game
{
    public interface IPlayerSimulation
    {
        void CreatePlayer(IWeaponInput weaponInput, IWeaponWithMagazine weapon);
    }
}
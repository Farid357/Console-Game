using Console_Game.Weapons;

namespace Console_Game
{
    public interface IPlayerSimulationView
    {
        void DeletePlayerWeapon(IWeaponWithMagazine weapon);
        
        void CreatePlayer(IWeaponWithMagazine weapon);
    }
}
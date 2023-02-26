using Console_Game.Weapons;

namespace Console_Game
{
    public interface IPlayerSimulation
    {
        IPlayer CurrentPlayer { get; }

        void DeleteCurrentPlayer();
        
        IPlayer CreatePlayer(IWeaponInput weaponInput, IWeaponWithMagazine weapon);
        
        bool HasPlayer();
    }
}
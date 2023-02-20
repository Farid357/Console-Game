using System;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class PlayerSimulation : IPlayerSimulation
    {
        private readonly IGameUpdate _gameUpdate;
        private Player _lastCreatedPlayer;

        public PlayerSimulation(IGameUpdate gameUpdate)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }

        public IPlayer CreatePlayer(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            if (weaponInput == null) 
                throw new ArgumentNullException(nameof(weaponInput));
            
            if (weapon == null) 
                throw new ArgumentNullException(nameof(weapon));
           
            if(_lastCreatedPlayer != null)
                _gameUpdate.Remove(_lastCreatedPlayer);

            _lastCreatedPlayer = new Player(weaponInput, weapon);
            _gameUpdate.Add(_lastCreatedPlayer);
            return _lastCreatedPlayer;
        }
    }
}
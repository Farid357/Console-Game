using System;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class PlayerSimulation : IPlayerSimulation
    {
        private readonly IGameUpdate _gameUpdate;
        private Player _currentPlayer;

        public PlayerSimulation(IGameUpdate gameUpdate)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }

        public IPlayer CurrentPlayer => _currentPlayer;

        public void DeleteCurrentPlayer()
        {
            if (CurrentPlayer == null)
                throw new InvalidOperationException($"Simulation doesn't have player!");
            
            _gameUpdate.Remove(_currentPlayer);
        }

        public IPlayer CreatePlayer(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            if (weaponInput == null) 
                throw new ArgumentNullException(nameof(weaponInput));
            
            if (weapon == null) 
                throw new ArgumentNullException(nameof(weapon));
           
            _currentPlayer = new Player(weaponInput, weapon);
            _gameUpdate.Add(_currentPlayer);
            return _currentPlayer;
        }
    }
}
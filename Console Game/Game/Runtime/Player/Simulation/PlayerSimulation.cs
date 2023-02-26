using System;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class PlayerSimulation : IPlayerSimulation
    {
        private readonly IGameUpdate _gameUpdate;
        private readonly IPlayerSimulationView _view;
        private Player _currentPlayer;

        public PlayerSimulation(IGameUpdate gameUpdate, IPlayerSimulationView view)
        {
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public IPlayer CurrentPlayer => _currentPlayer;

        public bool HasPlayer() => CurrentPlayer != null;

        public void DeleteCurrentPlayer()
        {
            if (HasPlayer() == false)
                throw new InvalidOperationException($"Simulation doesn't have player!");

            _gameUpdate.Remove(_currentPlayer);
            _view.DeletePlayerWeapon(_currentPlayer.Weapon);
        }

        public IPlayer CreatePlayer(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            if (weaponInput == null)
                throw new ArgumentNullException(nameof(weaponInput));

            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            _currentPlayer = new Player(weaponInput, weapon);
            _gameUpdate.Add(_currentPlayer);
            _view.CreatePlayer(_currentPlayer.Weapon);
            return _currentPlayer;
        }
    }
}
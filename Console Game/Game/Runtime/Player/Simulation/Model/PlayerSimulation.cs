using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game.Loop;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class PlayersSimulation<TPlayer> : IPlayersSimulation<TPlayer> where TPlayer : IPlayer
    {
        private readonly IPlayersSimulationView<TPlayer> _view;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly List<TPlayer> _players = new List<TPlayer>();
        private TPlayer _currentPlayer;
        
        public PlayersSimulation(IGroup<IGameLoopObject> gameLoopObjects, IPlayersSimulationView<TPlayer> view)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public IReadOnlyList<IReadOnlyPlayer> Players => _players.ToReadOnly();

        public IReadOnlyPlayer CurrentPlayer => _currentPlayer;

        public bool HasPlayer() => CurrentPlayer != null;

        public void DeleteCurrentPlayer()
        {
            if (HasPlayer() == false)
                throw new InvalidOperationException($"Simulation doesn't have player!");

            _players.Remove(_currentPlayer);
            _gameLoopObjects.Remove(_currentPlayer);
            _view.DeletePlayer(_currentPlayer);
            _currentPlayer = _players.Last();
        }

        public void Add(TPlayer player)
        {
            _players.Add(player);
            _gameLoopObjects.Add(player);
            _view.CreatePlayer(player);
            _currentPlayer = player;
        }
    }
}
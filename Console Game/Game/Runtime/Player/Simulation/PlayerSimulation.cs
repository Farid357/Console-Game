using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class PlayersSimulation<TPlayer> : IPlayersSimulation<TPlayer> where TPlayer : IPlayer
    {
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly List<TPlayer> _players = new List<TPlayer>();
        private TPlayer _currentPlayer;

        public PlayersSimulation(IGroup<IGameLoopObject> gameLoopObjects)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }

        public IReadOnlyList<IReadOnlyPlayer> Players => _players.ToReadOnly();

        public IReadOnlyPlayer CurrentPlayer => _currentPlayer;

        public bool HasPlayer() => CurrentPlayer != null;

        public void Add(TPlayer player)
        {
            _players.Add(player);
            _gameLoopObjects.Add(player);
            _currentPlayer = player;
        }

        public void DeleteCurrentPlayer()
        {
            if (HasPlayer() == false)
                throw new InvalidOperationException($"Simulation doesn't have player!");

            _players.Remove(_currentPlayer);
            _gameLoopObjects.Remove(_currentPlayer);
            _currentPlayer = _players.Last();
        }
    }
}
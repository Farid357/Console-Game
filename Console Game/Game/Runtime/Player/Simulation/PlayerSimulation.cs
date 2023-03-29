using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.GameLoop;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class PlayersSimulation<TPlayer> : IPlayersSimulation<TPlayer> where TPlayer : IPlayer
    {
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly List<TPlayer> _players = new List<TPlayer>();
        private TPlayer _currentPlayer;

        public PlayersSimulation(IGameLoopObjectsGroup gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public IReadOnlyList<IReadOnlyPlayer> Players => _players.ToReadOnly();

        public IReadOnlyPlayer CurrentPlayer => _currentPlayer;

        public bool HasPlayer() => CurrentPlayer != null;

        public void Add(TPlayer player)
        {
            _players.Add(player);
            _gameLoop.Add(player);
            _currentPlayer = player;
        }

        public void DeleteCurrentPlayer()
        {
            if (HasPlayer() == false)
                throw new InvalidOperationException($"Simulation doesn't have player!");

            _players.Remove(_currentPlayer);
            _gameLoop.Remove(_currentPlayer);

            if (_players.Count > 0)
                _currentPlayer = _players.Last();
        }
    }
}
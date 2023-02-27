using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game.Loop;

namespace Console_Game
{
    public sealed class PlayersSimulation<TPlayer> : IPlayersSimulation<TPlayer> where TPlayer : IPlayer
    {
        private readonly IPlayersSimulationView<TPlayer> _view;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly List<TPlayer> _players = new List<TPlayer>();

        public PlayersSimulation(IGroup<IGameLoopObject> gameLoopObjects, IPlayersSimulationView<TPlayer> view)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public IReadOnlyList<TPlayer> Players => _players;

        public TPlayer CurrentPlayer => Players.Last();

        public bool HasPlayer() => CurrentPlayer != null;

        public void DeleteCurrentPlayer()
        {
            if (HasPlayer() == false)
                throw new InvalidOperationException($"Simulation doesn't have player!");

            _players.Remove(CurrentPlayer);
            _gameLoopObjects.Remove(CurrentPlayer);
            _view.DeletePlayer(CurrentPlayer);
        }

        public void Add(TPlayer player)
        {
            _players.Add(player);
            _gameLoopObjects.Add(player);
            _view.CreatePlayer(player);
        }
    }
}
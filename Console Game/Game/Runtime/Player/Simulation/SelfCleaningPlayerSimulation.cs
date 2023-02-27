using System;
using System.Collections.Generic;

namespace Console_Game
{
    public sealed class SelfCleaningPlayerSimulation<TPlayer> : IPlayersSimulation<TPlayer> where TPlayer : IPlayer
    {
        private readonly IPlayersSimulation<TPlayer> _playersSimulation;

        public SelfCleaningPlayerSimulation(IPlayersSimulation<TPlayer> playersSimulation)
        {
            _playersSimulation = playersSimulation ?? throw new ArgumentNullException(nameof(playersSimulation));
        }

        public IReadOnlyList<TPlayer> Players => _playersSimulation.Players;

        public TPlayer CurrentPlayer => _playersSimulation.CurrentPlayer;

        public bool HasPlayer() => _playersSimulation.HasPlayer();

        public void DeleteCurrentPlayer() => _playersSimulation.DeleteCurrentPlayer();

        public void Add(TPlayer player)
        {
            if (HasPlayer())
                DeleteCurrentPlayer();
            
            _playersSimulation.Add(player);
        }
    }
}
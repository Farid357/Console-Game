using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IReadOnlyPlayersSimulation
    {
        IReadOnlyList<IReadOnlyPlayer> Players { get; }
        
        IReadOnlyPlayer CurrentPlayer { get; }

        bool HasPlayer();
    }
}
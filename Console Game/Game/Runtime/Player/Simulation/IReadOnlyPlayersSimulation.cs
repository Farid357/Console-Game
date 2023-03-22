using System.Collections.Generic;

namespace Console_Game
{
    public interface IReadOnlyPlayersSimulation
    {
        IReadOnlyList<IReadOnlyPlayer> Players { get; }
        
        IReadOnlyPlayer CurrentPlayer { get; }

        bool HasPlayer();
    }
}
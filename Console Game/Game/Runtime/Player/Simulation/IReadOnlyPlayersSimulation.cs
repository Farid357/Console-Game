using System.Collections.Generic;

namespace Console_Game
{
    public interface IReadOnlyPlayersSimulation<out TPlayer>
    {
        IReadOnlyList<TPlayer> Players { get; }
        
        TPlayer CurrentPlayer { get; }

        bool HasPlayer();
    }
}
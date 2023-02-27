using System;

namespace Console_Game
{
    public sealed class PlayersSimulationView<TPlayer> : IPlayersSimulationView<TPlayer> where TPlayer : IPlayer
    {
        public void DeletePlayer(TPlayer player)
        {
            Console.WriteLine($"Disable player weapon {player.Weapon}");
        }

        public void CreatePlayer(TPlayer player)
        {
            Console.WriteLine($"Enable new player weapon {player.Weapon}");
        }
    }
}
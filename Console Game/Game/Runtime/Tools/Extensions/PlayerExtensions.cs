using System.Collections.Generic;
using System.Linq;

namespace Console_Game.Tools
{
    public static class PlayerExtensions
    {
        public static IReadOnlyList<IReadOnlyPlayer> ToReadOnly<TPlayer>(this IReadOnlyList<TPlayer> players) where TPlayer : IPlayer
        {
            return players.Cast<IReadOnlyPlayer>().ToList();
        }
    }
}
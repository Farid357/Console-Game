using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Tools
{
    public static class PlayerExtensions
    {
        public static IReadOnlyList<IReadOnlyShooter<TWeapon>> ToReadOnly<TShooter, TWeapon>(this IReadOnlyList<TShooter> players)
        {
            return players.Cast<IReadOnlyShooter<TWeapon>>().ToList();
        }
    }
}
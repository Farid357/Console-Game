using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IReadOnlyPlayersSimulation<out TWeapon>
    {
        IReadOnlyList<IReadOnlyShooter<TWeapon>> Players { get; }
        
        IReadOnlyShooter<TWeapon> CurrentShooter { get; }

        bool HasPlayer();
    }
}
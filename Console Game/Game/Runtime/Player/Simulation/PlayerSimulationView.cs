using System;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class PlayerSimulationView : IPlayerSimulationView
    {
        public void DeletePlayerWeapon(IWeaponWithMagazine weapon)
        {
            Console.WriteLine($"Disable player weapon {weapon}");
        }

        public void CreatePlayer(IWeaponWithMagazine weapon)
        {
            Console.WriteLine($"Enable new player weapon {weapon}");
        }
    }
}
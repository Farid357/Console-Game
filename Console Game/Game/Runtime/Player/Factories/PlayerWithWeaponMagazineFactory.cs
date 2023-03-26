using System;
using ConsoleGame.Weapons;

namespace ConsoleGame
{
    public sealed class PlayerWithWeaponMagazineFactory : IPlayerFactory<IWeaponWithMagazine, IWeaponInput, IPlayerWithWeaponMagazine>
    {
        private readonly IPlayersSimulation<IPlayerWithWeaponMagazine> _playersSimulation;

        public PlayerWithWeaponMagazineFactory(IPlayersSimulation<IPlayer> playersSimulation)
        {
            _playersSimulation = playersSimulation ?? throw new ArgumentNullException(nameof(playersSimulation));
        }

        public IPlayerWithWeaponMagazine Create(IWeaponInput weaponInput, IWeaponWithMagazine weapon)
        {
            IPlayerWithWeaponMagazine player = new PlayerWithWeaponMagazine(weaponInput, weapon);
            _playersSimulation.Add(player);
            return player;
        }
    }
}
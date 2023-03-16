using System;

namespace Console_Game
{
    public sealed class PlayerFactory : IPlayerFactory<IWeapon, IWeaponInput>
    {
        private readonly IPlayersSimulation<IPlayer> _playersSimulation;

        public PlayerFactory(IPlayersSimulation<IPlayer> playersSimulation)
        {
            _playersSimulation = playersSimulation ?? throw new ArgumentNullException(nameof(playersSimulation));
        }

        public IReadOnlyPlayer Create(IWeaponInput weaponInput, IWeapon weapon)
        {
            IPlayer player = new Player(weaponInput, weapon);
            _playersSimulation.Add(player);
            return player;
        }
    }
}
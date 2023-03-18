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

//     public sealed class PlayerWithTwoWeaponFactory<TWeapon, TWeaponInput, TSecondWeapon, TSecondWeaponInput>
//         where TSecondWeapon : IWeapon
//         where TSecondWeaponInput : IWeaponInput
//         where TWeaponInput : IWeaponInput
//         where TWeapon : IWeapon
//     {
//         private readonly IPlayersSimulation<IPlayerWithTwoWeapon> _playersSimulation;
//
//
//         public IReadOnlyPlayer Create(TWeaponInput weaponInput, TWeapon weapon, TSecondWeaponInput secondWeaponInput,
//             TSecondWeapon secondWeapon)
//         {
// _playersSimulation.Add(new PlayerWithTwoWeapons<IPlayer, IPlayer>(new PlayerWithWeaponMagazine()));
//             return player;
//         }
//     }
}
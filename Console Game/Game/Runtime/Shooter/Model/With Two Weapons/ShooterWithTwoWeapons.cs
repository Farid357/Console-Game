using System;

namespace ConsoleGame
{
    public sealed class ShooterWithTwoWeapons<TFirstWeapon, TSecondWeapon> : IShooterWithTwoWeapon<TFirstWeapon, TSecondWeapon>
    {
        private readonly IShooter<TFirstWeapon> _firstPlayer;
        private readonly IShooter<TSecondWeapon> _secondPlayer;

        public ShooterWithTwoWeapons(IShooter<TFirstWeapon> firstPlayer, IShooter<TSecondWeapon> secondPlayer)
        {
            _firstPlayer = firstPlayer ?? throw new ArgumentNullException(nameof(firstPlayer));
            _secondPlayer = secondPlayer ?? throw new ArgumentNullException(nameof(secondPlayer));
        }

        public TFirstWeapon FirstWeapon => _firstPlayer.Weapon;
        
        public TSecondWeapon SecondWeapon => _secondPlayer.Weapon;

        public void Update(float deltaTime)
        {
            _firstPlayer.Update(deltaTime);
            _secondPlayer.Update(deltaTime);
        }

    }
}
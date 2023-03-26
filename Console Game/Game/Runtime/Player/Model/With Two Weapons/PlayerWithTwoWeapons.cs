namespace ConsoleGame
{
    public sealed class PlayerWithTwoWeapons<TFirstPlayer, TSecondPlayer> : IPlayerWithTwoWeapon where TFirstPlayer : IPlayer where TSecondPlayer : IPlayer
    {
        private readonly TFirstPlayer _firstPlayer;
        private readonly TSecondPlayer _secondPlayer;

        public PlayerWithTwoWeapons(TFirstPlayer firstPlayer, TSecondPlayer secondPlayer)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
        }

        public IWeaponInput WeaponInput => _firstPlayer.WeaponInput;

        public IWeapon Weapon => _secondPlayer.Weapon;

        public IWeaponInput SecondWeaponInput => _secondPlayer.WeaponInput;

        public IWeapon SecondWeapon => _secondPlayer.Weapon;

        public void Update(float deltaTime)
        {
            _firstPlayer.Update(deltaTime);
            _secondPlayer.Update(deltaTime);
        }
    }
}
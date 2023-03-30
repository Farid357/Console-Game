namespace ConsoleGame
{
    public interface IWeapon
    {
        bool CanShoot { get; }

        void Shoot();
    }

    public sealed class TwoWeapons : IWeapon
    {
        private readonly IWeapon _firstWeapon;
        private readonly IWeapon _secondWeapon;

        public TwoWeapons(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
        }

        public bool CanShoot => _firstWeapon.CanShoot || _secondWeapon.CanShoot;
        
        public void Shoot()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IThrowingWeapon
    {
        void Throw();
    }
}
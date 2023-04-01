namespace ConsoleGame.Tests
{
    public sealed class DummyWeapon : IWeapon
    {
        public bool CanShoot => true;
        
        public IWeaponActivityView View { get; } = new NullWeaponView();

        public void Shoot()
        {
        }
    }
}
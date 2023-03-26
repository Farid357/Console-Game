namespace ConsoleGame.Tests
{
    public sealed class DummyWeapon : IWeapon
    {
        public bool CanShoot => true;
        
        public void Shoot()
        {
            
        }
    }
}
namespace Console_Game.Tests
{
    public sealed class DummyWeapon : IWeapon
    {
        public bool CanShoot => true;
        
        public void Shoot()
        {
            
        }
    }
}
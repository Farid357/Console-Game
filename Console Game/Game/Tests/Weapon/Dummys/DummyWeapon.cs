using Console_Game;

namespace ConsoleGame.Tests
{
    public sealed class DummyWeapon : IWeapon
    {
        public bool CanShoot => true;

        public IWeaponData Data { get; } = new WeaponData(false, 10, new Timer(3f), new NullWeaponMagazine(),
            new NullWeaponView(), new NullBattery());

        public void Shoot()
        {
        }
    }
}
using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class WeaponWithShootWaitingTest
    {
        [Test]
        public void NeedWaitShoot()
        {
            IWeapon weapon = new WeaponWithShootWaiting(new Timer(10), new DummyWeapon());
            weapon.Shoot();
            Assert.That(weapon.CanShoot == false);
        }
        
        [Test]
        public void WaitsShoot()
        {
            var cooldownTimer = new Timer(3);
            IWeapon weapon = new WeaponWithShootWaiting(cooldownTimer, new DummyWeapon());
            weapon.Shoot();
            cooldownTimer.Update(3);
            Assert.That(weapon.CanShoot);
        }
    }
}
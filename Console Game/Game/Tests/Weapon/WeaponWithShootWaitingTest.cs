using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class WeaponWithShootWaitingTest
    {
        [Test]
        public void NeedWaitShoot()
        {
            IWeapon weapon = new WeaponWithRateOfShot(new DummyWeapon(), new Timer(10f));
            Assert.That(weapon.CanShoot == false);
        }
        
        [Test]
        public void WaitsShoot()
        {
            IWeapon weaponDummy = new DummyWeapon();
            var cooldownTimer = new Timer(3f);
            IWeapon weapon = new WeaponWithRateOfShot(weaponDummy, cooldownTimer);
            cooldownTimer.Update(3);
            weapon.Shoot();
            cooldownTimer.Update(3);
            Assert.That(weapon.CanShoot);
        }
    }
}
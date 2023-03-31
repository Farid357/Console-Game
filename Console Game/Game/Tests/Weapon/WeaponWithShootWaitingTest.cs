using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class WeaponWithShootWaitingTest
    {
        [Test]
        public void NeedWaitShoot()
        {
            IWeapon weapon = new WeaponWithShootWaiting(new DummyWeapon());
            Assert.That(weapon.CanShoot == false);
        }
        
        [Test]
        public void WaitsShoot()
        {
            IWeapon weaponDummy = new DummyWeapon();
            var cooldownTimer = (Timer)weaponDummy.Data.CooldownTimer;
            IWeapon weapon = new WeaponWithShootWaiting(weaponDummy);
            cooldownTimer.Update(3);
            weapon.Shoot();
            cooldownTimer.Update(3);
            Assert.That(weapon.CanShoot);
        }
    }
}
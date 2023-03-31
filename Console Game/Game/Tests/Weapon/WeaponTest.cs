using Console_Game;
using ConsoleGame.Weapons;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class WeaponTest
    {
        [Test]
        public void ThrowsBullet()
        {
            var bulletsFactory = new DummyBulletFactory();
            ITimer cooldownTimer = new Timer(0.2f);
            IWeapon weapon = new CharacterWeapon(bulletsFactory, new DummyMovement(),
                new WeaponData(false, 10, cooldownTimer, new NullWeaponMagazine(), new NullWeaponView(), new NullBattery()));
            weapon.Shoot();
            Assert.That(bulletsFactory.CreatedBullet.WasThrew);
        }
    }
}
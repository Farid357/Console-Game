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
            IWeapon weapon = new CharacterWeapon(bulletsFactory,  new DummyMovement(), 10);
            weapon.Shoot();
            Assert.That(bulletsFactory.CreatedBullet.WasThrew);
        }
    }
}
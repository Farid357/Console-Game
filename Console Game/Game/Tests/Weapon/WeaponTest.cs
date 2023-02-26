using Console_Game.Weapons;
using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class WeaponTest
    {
        [Test]
        public void ThrowsBullet()
        {
            var bulletsFactory = new DummyBulletsFactory();
            IWeapon weapon = new Weapon(bulletsFactory);
            weapon.Shoot();
            Assert.That(bulletsFactory.CreatedBullet.WasThrew);
        }
    }
}
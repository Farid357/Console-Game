using ConsoleGame.Weapons;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class WeaponWithMagazineTest
    {
        [Test]
        public void TakesBulletFromMagazine()
        {
            var bulletsFactory = new DummyBulletFactory();
            IWeaponMagazine weaponMagazine = new WeaponMagazine(10, new DummyMagazineView());
            IWeapon weapon = new WeaponWithMagazine(new Weapons.Weapon(bulletsFactory, new DummyAim(), new NullWeaponView(), 10), weaponMagazine);
            weapon.Shoot();
            Assert.That(weaponMagazine.Bullets == 9);
        }
    }
}
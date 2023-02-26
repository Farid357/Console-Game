using Console_Game.Weapons;
using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class WeaponWithMagazineTest
    {
        [Test]
        public void TakesBulletFromMagazine()
        {
            var bulletsFactory = new DummyBulletsFactory();
            IWeaponMagazine weaponMagazine = new WeaponMagazine(10, new DummyMagazineView());
            IWeapon weapon = new WeaponWithMagazine(weaponMagazine, new Weapon(bulletsFactory), new DummyWeaponWithMagazineView());
            weapon.Shoot();
            Assert.That(weaponMagazine.Bullets == 9);
        }

        [Test]
        public void ReloadsCorrectly()
        {
            var bulletsFactory = new DummyBulletsFactory();
            IWeaponMagazine weaponMagazine = new WeaponMagazine(10, new DummyMagazineView());
            IWeaponWithMagazine weapon = new WeaponWithMagazine(weaponMagazine, new Weapon(bulletsFactory), new DummyWeaponWithMagazineView());
            
            for (var i = 0; i < 9; i++)
            {
                weapon.Shoot();
            }

            weapon.Reload();
            Assert.That(weaponMagazine.Bullets == weaponMagazine.MaxBullets);
        }
    }
}
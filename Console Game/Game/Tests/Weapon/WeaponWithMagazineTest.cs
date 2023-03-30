using System.Threading.Tasks;
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
            IWeapon weapon = new WeaponWithMagazine(weaponMagazine, new CharacterWeapon(bulletsFactory, new DummyMovement(),10), new DummyWeaponWithReloadingView());
            weapon.Shoot();
            Assert.That(weaponMagazine.Bullets == 9);
        }

        [Test]
        public async Task ReloadsCorrectly()
        {
            var bulletsFactory = new DummyBulletFactory();
            IWeaponMagazine magazine = new WeaponMagazine(10, new DummyMagazineView());
            var weapon = new WeaponWithReloading(new WeaponWithMagazine(magazine, new DummyWeapon(), new DummyWeaponWithReloadingView()), new DummyWeaponWithReloadingView());
            
            for (var i = 0; i < 9; i++)
            {
                weapon.Shoot();
            }

            await weapon.Reload();
            Assert.That(magazine.Bullets == magazine.MaxBullets);
        }
    }
}
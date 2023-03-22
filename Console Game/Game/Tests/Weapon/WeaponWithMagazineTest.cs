using System.Threading.Tasks;
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
            IWeapon weapon = new WeaponWithMagazine(weaponMagazine, new Weapon(bulletsFactory, 10), new DummyWeaponWithMagazineView());
            weapon.Shoot();
            Assert.That(weaponMagazine.Bullets == 9);
        }

        [Test]
        public async Task ReloadsCorrectly()
        {
            var bulletsFactory = new DummyBulletsFactory();
            IWeaponMagazine weaponMagazine = new WeaponMagazine(10, new DummyMagazineView());
            IWeaponWithMagazine weapon = new WeaponWithMagazine(weaponMagazine, new Weapon(bulletsFactory, 10), new DummyWeaponWithMagazineView());
            
            for (var i = 0; i < 9; i++)
            {
                weapon.Shoot();
            }

            await weapon.Reload();
            Assert.That(weaponMagazine.Bullets == weaponMagazine.MaxBullets);
        }
    }
}
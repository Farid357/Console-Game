using System.Threading.Tasks;
using Console_Game;
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
            WeaponData weaponData = new WeaponData(false, 1, new Timer(1.2f), weaponMagazine, new NullWeaponView(), new NullBattery());
            IWeapon weapon = new WeaponWithMagazine(new CharacterWeapon(bulletsFactory, new DummyMovement(), weaponData));
            weapon.Shoot();
            Assert.That(weaponMagazine.Bullets == 9);
        }
    }
}
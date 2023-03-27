using ConsoleGame.Tools;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class ArmorTest
    {
        [Test]
        public void TakesDamageCorrectly()
        {
            IHealth health = new Health(10);
            IHealth armor = new Armor(health, new ArmorView(), 10);
            armor.TakeDamage(10);
            Assert.That(health.Value == 10);
            armor.TakeDamage(10);
            Assert.That(health.IsDied());
        }
    }
}
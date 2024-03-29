using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class HealthTest
    {
        [Test]
        public void HealsCorrectly()
        {
            IHealth health = new Health(10);
            health.TakeDamage(5);
            health.Heal(5);
            Assert.That(health.Value == 10);
        }
        
        [Test]
        public void AfterHealTakesDamageCorrectly()
        {
            IHealth health = new Health(10);
            health.TakeDamage(5);
            health.Heal(5);
            health.TakeDamage(5);
            Assert.That(health.Value == 5);
        }
    }
}
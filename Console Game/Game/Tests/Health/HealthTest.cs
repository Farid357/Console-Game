using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class HealthTest
    {
        [Test]
        public void HealsCorrectly()
        {
            IHealth health = new Health(new DummyHealthView(), 10);
            health.TakeDamage(5);
            health.Heal(5);
            Assert.That(health.Value == health.MaxValue);
        }
        
        [Test]
        public void AfterHealTakesDamageCorrectly()
        {
            IHealth health = new Health(new DummyHealthView(), 10);
            health.TakeDamage(5);
            health.Heal(5);
            health.TakeDamage(5);
            Assert.That(health.Value == 5);
        }
    }
}
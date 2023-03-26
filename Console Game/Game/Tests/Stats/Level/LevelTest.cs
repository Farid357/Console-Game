using ConsoleGame.Stats;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class LevelTest
    {
        [Test]
        public void IsFullWorksCorrectly()
        {
            ILevel level = new Level(new LevelView(string.Empty, new DummyText()), startXp: 0, maxXp: 10);
            level.Increase(10);
            Assert.That(level.IsFull);
        }

        [Test]
        public void IncreaseXpCorrectly()
        {
            ILevel level = new Level(new LevelView(string.Empty, new DummyText()), startXp: 0, maxXp: 7);
            level.Increase(5);
            Assert.That(level.Xp == 5);
        }
    }
}
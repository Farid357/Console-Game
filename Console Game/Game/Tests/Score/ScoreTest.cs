using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class ScoreTest
    {
        [Test]
        public void RaiseCorrectly()
        {
            IScore score = new Score(new ScoreView(), 10);
            score.Raise(5);
            Assert.That(score.Count == 15);
        }
    }
}
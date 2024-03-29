using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class ScoreBestRecordTest
    {
        [Test]
        public void RaiseCorrectly()
        {
            IScore score = new Score(new ScoreView(new DummyText()), 10);
            var bestRecord = new ScoreBestRecord(score, new DummySaveStorage<int>(), new ScoreBestRecordView(new DummyText()));
            bestRecord.Update(0.1f);
            score.Raise(5);
            bestRecord.Update(0.2f);
            Assert.That(bestRecord.Count == 15);
        }
    }
}
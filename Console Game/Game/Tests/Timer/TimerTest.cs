using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class TimerTest
    {
        [Test]
        public void SpendsTimeCorrectly()
        {
            var timer = new Timer(cooldown: 10);
            timer.Play();
            timer.Update(3f);
            Assert.That(timer.Time == 3f);
        }
        
        public void EndingCorrectly()
        {
            var timer = new Timer(cooldown: 10);
            timer.Play();
            timer.Update(10);
            Assert.That(timer.IsEnded);
        }
    }
}
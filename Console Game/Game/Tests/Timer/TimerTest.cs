using System.Threading.Tasks;
using ConsoleGame.Tools;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class TimerTest
    {
        [Test]
        public void SpendsTimeCorrectly()
        {
            var timer = new Timer(cooldown: 10);
            timer.Update(3f);
            Assert.That(timer.Time == 3f);
        }
        
        [Test]
        public void EndingCorrectly()
        {
            var timer = new Timer(cooldown: 10);
            timer.Update(10);
            Assert.That(timer.IsEnded);
        }
    }
}
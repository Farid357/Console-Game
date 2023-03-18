using System.Threading.Tasks;
using Console_Game.Tools;
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
        
        [Test]
        public void EndingCorrectly()
        {
            var timer = new Timer(cooldown: 10);
            timer.Play();
            timer.Update(10);
            Assert.That(timer.IsEnded);
        }
        
        [Test]
        public async Task EndExtensionMethodWorks()
        {
            var timer = new Timer(cooldown: 10);
            timer.Play();
            await timer.End();
            Assert.That(timer.IsEnded);
        }
    }
}
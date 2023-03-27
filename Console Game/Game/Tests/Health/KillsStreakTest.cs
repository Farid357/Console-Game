using System.Collections.Generic;
using ConsoleGame.Tools;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class KillsStreakTest
    {
        [Test]
        public void CountsCorrectly()
        {
            IHealth enemyHealth = new Health( 100);
            IReadOnlyList<IEnemy> enemies = new []{new DummyEnemy(enemyHealth)};
            var killsStreak = new KillsStreak(enemies, new KillsStreakView(new DummyText()), new Health( 50));
            enemyHealth.Kill();
            killsStreak.Update(0.01f);
            Assert.That(killsStreak.Factor == 1);
        }
        
        [Test]
        public void ResetsCorrectly()
        {
            IHealth enemyHealth = new Health(100);
            IReadOnlyList<IEnemy> enemies = new []{new DummyEnemy(enemyHealth)};
            IHealth characterHealth = new Health( 50);
            var killsStreak = new KillsStreak(enemies, new KillsStreakView(new DummyText()), characterHealth);
            enemyHealth.Kill();
            killsStreak.Update(0.01f);
            Assert.That(killsStreak.Factor == 1);
            characterHealth.TakeDamage(12);
            killsStreak.Update(0.2f);
            Assert.That(killsStreak.Factor == 0);
        }
    }
}
using System.Collections.Generic;
using ConsoleGame.SaveSystem;
using ConsoleGame.Stats;
using NUnit.Framework;

namespace ConsoleGame.Tests
{
    [TestFixture]
    public sealed class LevelWithSaveTest
    {
        [Test]
        public void SaveCorrectly()
        {
            ILevelView levelView = new DummyLevelView();
            ISaveStorage<ILevel> saveStorage = new BinaryStorage<ILevel>(new Path("djodridjes"));
            List<ILevel> levels = new List<ILevel>{new Level(levelView, startXp: 10, maxXp: 20)};
            ILevel level = new ChainOfLevel(levels, saveStorage);
            level.Increase(1);
            ILevel loadedLevel = saveStorage.Load();
            Assert.That(loadedLevel.Xp == level.Xp);
            loadedLevel.Increase(1);
        }
    }
}
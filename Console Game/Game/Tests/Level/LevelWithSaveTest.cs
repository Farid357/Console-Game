using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;
using Console_Game.Stats;
using NUnit.Framework;

namespace Console_Game.Tests
{
    [TestFixture]
    public sealed class LevelWithSaveTest
    {
        [Test]
        public void SaveCorrectly()
        {
            const string levelOwnerName = "b";
            var levelView = new DummyLevelView(levelOwnerName);
            ISaveStorage<ILevel> saveStorage = new BinaryStorage<ILevel>(new Path("djodridjes"));
            ILevel level = new LevelWithSave(new Level(levelView, startXp: 10, maxXp: 20), saveStorage);
            level.Increase(1);
            ILevel loadedLevel = saveStorage.Load();
            Assert.That(loadedLevel.Xp == level.Xp);
            loadedLevel.Increase(1);
        }
    }
}
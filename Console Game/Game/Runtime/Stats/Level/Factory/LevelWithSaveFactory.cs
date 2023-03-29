using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.SaveSystem;
using ConsoleGame.Stats;

namespace ConsoleGame
{
    public sealed class LevelWithSaveFactory : IFactory<ILevel>
    {
        private readonly ISaveStorages _saveStorages;
        private readonly List<ILevel> _allLevels;

        public LevelWithSaveFactory(ISaveStorages saveStorages, List<ILevel> allReachableLevels)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _allLevels = allReachableLevels ?? throw new ArgumentNullException(nameof(allReachableLevels));
        }

        public ILevel Create()
        {
            ISaveStorage<ILevel> levelStorage = new BinaryStorage<ILevel>(new Path("Character Level"));
            _saveStorages.Add(levelStorage);

            if (levelStorage.HasSave())
            {
                var loadedXp = levelStorage.Load().Xp;
                ILevel savedLevel = _allLevels.Last(level => loadedXp >= level.Xp);
                return new LevelWithSave(new ChainOfLevel(_allLevels, savedLevel), levelStorage);
            }

            return new LevelWithSave(new ChainOfLevel(_allLevels, _allLevels.First()), levelStorage);
        }
    }
}
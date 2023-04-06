using System;
using System.Collections.Generic;
using ConsoleGame.SaveSystem;
using ConsoleGame.Stats;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class CharacterLevelFactory : ILevelFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly ISaveStorage<ILevel> _levelStorage;
        private readonly List<ILevel> _allLevels;
        
        public CharacterLevelFactory(ISaveStorages saveStorages, ILevelViewFactory viewFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _levelStorage = new BinaryStorage<ILevel>(new Path("Character Level"));
            ILevelView levelView = viewFactory.Create();
            _allLevels = CreateLevels(levelView);
        }

        private List<ILevel> CreateLevels(ILevelView levelView)
        {
            return new List<ILevel>
            {
                new Level(levelView, startXp: 0, maxXp: 10),
                new Level(levelView, startXp: 10, maxXp: 20),
                new Level(levelView, startXp: 20, maxXp: 50),
                new Level(levelView, startXp: 50, maxXp: 100)
            };
        }
        
        public ILevel Create()
        {
            _saveStorages.Add(_levelStorage);
            IChainOfLevel chainOfLevel = new ChainOfLevel(_allLevels, _levelStorage);
            chainOfLevel.CurrentLevel.Visualize();
            return chainOfLevel;
        }
    }
}
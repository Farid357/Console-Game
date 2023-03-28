using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.Stats;

namespace ConsoleGame
{
    public sealed class LevelFactory : IFactory<ILevel>
    {
        private readonly List<ILevel> _allReachableLevels;

        public LevelFactory(List<ILevel> allReachableLevels)
        {
            _allReachableLevels = allReachableLevels ?? throw new ArgumentNullException(nameof(allReachableLevels));
        }

        public ILevel Create()
        {
            return new ChainOfLevel(_allReachableLevels, _allReachableLevels.First());
        }
    }
}
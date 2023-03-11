using System;
using System.Collections.Generic;
using System.Linq;
using Console_Game.Stats;

namespace Console_Game
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
            return new ConsecutiveLevels(_allReachableLevels, _allReachableLevels.First());
        }
    }
}
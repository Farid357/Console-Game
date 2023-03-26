using System;
using System.Collections.Generic;
using ConsoleGame.Stats;

namespace ConsoleGame
{
    public sealed class CharacterLevelsFactory : ILevelsFactory
    {
        private readonly ILevelViewFactory _viewFactory;

        public CharacterLevelsFactory(ILevelViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public List<ILevel> Create()
        {
            ILevelView levelView = _viewFactory.Create();
            
            return new List<ILevel>
            {
                new Level(levelView, startXp: 0, maxXp: 10),
                new Level(levelView, startXp: 10, maxXp: 20),
                new Level(levelView, startXp: 20, maxXp: 50),
                new Level(levelView, startXp: 50, maxXp: 100)
            };
        }
    }
}
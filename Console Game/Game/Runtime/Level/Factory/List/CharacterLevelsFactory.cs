using System.Collections.Generic;
using Console_Game.Stats;

namespace Console_Game
{
    public sealed class CharacterLevelsFactory : ILevelsFactory
    {
        public List<ILevel> Create()
        {
            ILevelView levelView = new LevelView("Player");

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
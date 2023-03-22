using System;
using System.Collections.Generic;
using System.Numerics;
using Console_Game.Stats;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class CharacterLevelsFactory : ILevelsFactory
    {
        private readonly ITextFactory _textFactory;

        public CharacterLevelsFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public List<ILevel> Create()
        {
            ITransform textTransform = new Transform(new Vector2(100, 250));
            IText text = _textFactory.Create(textTransform);
            ILevelView levelView = new LevelView("Player", text);

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
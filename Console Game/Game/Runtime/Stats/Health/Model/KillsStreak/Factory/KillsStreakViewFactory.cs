using System;
using System.Drawing;
using System.Numerics;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class KillsStreakViewFactory : IKillsStreakViewFactory
    {
        private readonly ITextFactory _textFactory;

        public KillsStreakViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IKillsStreakView Create()
        {
            var position = new Vector2(20, 50);
            var font = new Font("Arial", 24, FontStyle.Bold);
            IText text = _textFactory.Create(position, font);
            return new KillsStreakView(text);
        }
    }
}
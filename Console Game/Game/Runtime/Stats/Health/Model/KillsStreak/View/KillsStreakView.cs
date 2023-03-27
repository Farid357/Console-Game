using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class KillsStreakView : IKillsStreakView
    {
        private readonly IText _text;

        public KillsStreakView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int factor)
        {
            _text.Visualize($"X{factor}");
        }

        public void Reset()
        {
            _text.Visualize(string.Empty);
        }
    }
}
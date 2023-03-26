using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteBulletsView : IInfiniteBulletsView
    {
        private readonly IText _text;

        public InfiniteBulletsView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize()
        {
            _text.Visualize("\u221E");
            Console.WriteLine();
        }
    }
}
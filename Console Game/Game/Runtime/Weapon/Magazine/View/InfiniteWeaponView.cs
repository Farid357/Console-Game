using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InfiniteWeaponView : IInfiniteWeaponView
    {
        private readonly IText _text;

        public InfiniteWeaponView(IText text)
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
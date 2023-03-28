using System;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IText _text;

        public CharacterHealthView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(int value, int maxValue)
        {
            _text.Visualize($"Health: {maxValue}/{value}");
        }

        public void Die()
        {
            _text.Clear();
           //Destroy gameObject
        }
    }
}
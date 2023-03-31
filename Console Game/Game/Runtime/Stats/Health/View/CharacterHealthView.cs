using System;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IText _text;
        private readonly IBar _bar;
        
        public CharacterHealthView(IText text, IBar bar)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _bar = bar ?? throw new ArgumentNullException(nameof(bar));
        }

        public void Visualize(int health, int maxHealth)
        {
            _text.Visualize($"Health: {maxHealth}/{health}");
            _bar.SetSize(health / (float)maxHealth);
        }

        public void Die()
        {
            _text.Clear();
            _bar.SetSize(0);
        }
    }
}
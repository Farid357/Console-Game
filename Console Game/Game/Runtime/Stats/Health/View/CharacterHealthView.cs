using System;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IText _text;
        private readonly IGameObjectView _gameObjectView;

        public CharacterHealthView(IText text, IGameObjectView gameObjectView)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _gameObjectView = gameObjectView ?? throw new ArgumentNullException(nameof(gameObjectView));
        }

        public void Visualize(int maxValue, int value)
        {
            _text.Visualize($"Health: {maxValue}/{value}");
        }

        public void Die()
        {
            _text.Clear();
            _gameObjectView.Destroy();
        }
    }
}
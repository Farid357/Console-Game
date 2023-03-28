using System;
using System.Collections.Generic;
using System.Numerics;
using ConsoleGame.UI;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public interface IAchievementsFactory
    {
        void Create();
    }

    public interface IAchievementFactory
    {
        void Create();
    }

    public interface IAchievementViewFactory
    {
        IAchievementView Create(string receiveCongratulationText);
    }

    public sealed class AchievementViewFactory : IAchievementViewFactory
    {
        private readonly ITextFactory _textFactory;
        private readonly IImageFactory _imageFactory;

        public AchievementViewFactory(IImageFactory imageFactory, ITextFactory textFactory)
        {
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IAchievementView Create(string receiveCongratulationText)
        {
            var window = new FakeWindow();
            IText congratulationsText = _textFactory.Create(new Vector2(50, 50));
            IImage checkmark = _imageFactory.Create(new Transform(), "");
            return new AchievementView(window, congratulationsText, checkmark, receiveCongratulationText);
        }
    }

    public sealed class AchievementsFactory : IAchievementsFactory
    {
        private readonly List<IAchievementFactory> _factories;

        public AchievementsFactory(List<IAchievementFactory> factories)
        {
            _factories = factories ?? throw new ArgumentNullException(nameof(factories));
        }

        public void Create()
        {
            foreach (var factory in _factories)
            {
                factory.Create();
            }
        }
    }
}
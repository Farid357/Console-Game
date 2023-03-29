using System;
using System.Drawing;
using System.Numerics;
using ConsoleGame.UI;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class AchievementViewFactory : IAchievementViewFactory
    {
        private readonly IImageFactory _imageFactory;
        private readonly IWindowFactory _windowFactory;
        private readonly ITextFactory _textFactory;

        public AchievementViewFactory(IImageFactory imageFactory, IWindowFactory windowFactory, ITextFactory textFactory)
        {
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
            _windowFactory = windowFactory ?? throw new ArgumentNullException(nameof(windowFactory));
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IAchievementView Create()
        {
            IWindow achievementWindow = _windowFactory.Create(new Transform(new Vector2(70, 100)), "");
            IText congratulationText = _textFactory.Create(new Vector2(65, 100), Color.Purple);
            IAchievementReceiveWindow achievementReceiveWindow = new AchievementReceiveWindow(achievementWindow, congratulationText);
            IImage checkmark = _imageFactory.Create(new Transform(), "");
            return new AchievementView(checkmark, achievementReceiveWindow);
        }
    }
}
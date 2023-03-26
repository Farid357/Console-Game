using System;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame.LoadSystem
{
    public sealed class SceneLoadingView : ISceneLoadingView
    {
        private readonly IWindow _window;
        private readonly IText _text;

        public SceneLoadingView(IText text, IWindow window)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Enable()
        {
            _window.Open();
            _text.Visualize(string.Empty);
        }

        public void Visualize(float progress)
        {
            _text.Visualize(progress * 100);
        }

        public void Disable()
        {
            _window.Close();
            _text.Visualize(string.Empty);
        }
    }
}
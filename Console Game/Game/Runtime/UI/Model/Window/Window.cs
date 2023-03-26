using System;

namespace ConsoleGame.UI
{
    public sealed class Window : IWindow, IUiElement
    {
        private readonly IUiElement _uiElement;

        public Window(IUiElement uiElement)
        {
            _uiElement = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
        }

        public bool IsOpen => IsEnabled;

        public bool IsEnabled => _uiElement.IsEnabled;

        public ITransform Transform => _uiElement.Transform;

        public void Open() => Enable();

        public void Close() => Disable();

        public void Enable()
        {
            _uiElement.Enable();
        }

        public void Disable()
        {
            _uiElement.Disable();
        }
    }
}
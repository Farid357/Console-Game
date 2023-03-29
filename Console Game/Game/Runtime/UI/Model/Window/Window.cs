using System;

namespace ConsoleGame.UI
{
    public sealed class Window : IWindow, IUiElement
    {
        private readonly IImage _image;

        public Window(IImage image)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public bool IsOpen => IsEnabled;

        public bool IsEnabled => _image.IsEnabled;

        public ITransform Transform => _image.Transform;

        public void Open() => Enable();

        public void Close() => Disable();

        public void Enable()
        {
            _image.Enable();
        }

        public void Disable()
        {
            _image.Disable();
        }
    }
}
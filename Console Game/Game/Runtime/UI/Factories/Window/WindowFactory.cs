using System;

namespace ConsoleGame.UI
{
    public sealed class WindowFactory : IWindowFactory
    {
        private readonly IImageFactory _imageFactory;

        public WindowFactory(IImageFactory imageFactory)
        {
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }

        public IWindow Create(ITransform transform, string imageFileName)
        {
            IImage image = _imageFactory.Create(transform, imageFileName);
            return new Window(image);
        }
    }
}
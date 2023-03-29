using System;

namespace ConsoleGame.UI
{
    public sealed class BarFactory : IBarFactory
    {
        private readonly IImageFactory _imageFactory;

        public BarFactory(IImageFactory imageFactory)
        {
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }

        public IBar Create(ITransform transform, string imageFileName)
        {
            IImage image = _imageFactory.Create(transform, imageFileName);
            return new Bar(image);
        }
    }
}
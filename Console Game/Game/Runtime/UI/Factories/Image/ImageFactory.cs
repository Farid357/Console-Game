using System;
using System.Drawing;

namespace ConsoleGame.UI
{
    public sealed class ImageFactory : IImageFactory
    {
        private readonly IUiElementFactory _uiElementFactory;

        public ImageFactory(IUiElementFactory uiElementFactory)
        {
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
        }

        public IImage Create(ITransform transform, string imageFileName)
        {
            var bitmap = new Bitmap(imageFileName);
            IImage image = new Image(_uiElementFactory.Create(transform), bitmap);
            image.Draw();
            image.Enable();
            return image;
        }
    }
}
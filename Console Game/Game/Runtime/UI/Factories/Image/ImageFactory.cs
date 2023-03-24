using System;
using System.Drawing;

namespace Console_Game.UI
{
    public sealed class ImageFactory : IImageFactory
    {
        private readonly IUiElementFactory _uiElementFactory;
        private readonly string _fileName;
        private readonly Color _color;

        public ImageFactory(string fileName, IUiElementFactory uiElementFactory, Color color)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
            _color = color;
        }

        public IImage Create(ITransform transform)
        {
            var bitmap = new Bitmap(_fileName);
            IImage image = new Image(_uiElementFactory.Create(transform), bitmap);
            image.Draw();
            image.Enable();
            image.SwitchColor(_color);
            return image;
        }
    }
}
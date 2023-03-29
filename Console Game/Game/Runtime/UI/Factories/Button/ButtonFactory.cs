using System;

namespace ConsoleGame.UI
{
    public sealed class ButtonFactory : IButtonFactory
    {
        private readonly IImageFactory _imageFactory;

        public ButtonFactory(IImageFactory imageFactory)
        {
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }

        public IButton Create(ITransform transform, IButtonViewData viewData, string imageFileName)
        {
            IImage image = _imageFactory.Create(transform, imageFileName);
            IButtonView view = new ButtonView(image, viewData);
            IButton button = new Button(view, image);
            button.Enable();
            return button;
        }
    }
}
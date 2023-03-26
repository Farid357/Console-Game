using System;
using System.Drawing;

namespace ConsoleGame.UI
{
    public sealed class TextFactory : ITextFactory
    {
        private readonly IUiElementFactory _uiElementFactory;

        public TextFactory(IUiElementFactory uiElementFactory)
        {
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
        }

        public IText Create(ITransform transform, Font font, Color color)
        {
            IText text = new Text(_uiElementFactory.Create(transform), font);
            text.Enable();
            text.SwitchColor(color);
            return text;
        }
    }
}
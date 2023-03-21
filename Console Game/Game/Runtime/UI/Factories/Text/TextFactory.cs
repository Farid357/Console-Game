using System;
using System.Drawing;

namespace Console_Game.UI
{
    public sealed class TextFactory : ITextFactory
    {
        private readonly IUiElementFactory _uiElementFactory;
        private readonly Color _color;
        private readonly Font _font = new Font("Arial", 16);

        public TextFactory(IUiElementFactory uiElementFactory) : this(uiElementFactory, Color.Black)
        {
        }

        public TextFactory(IUiElementFactory uiElementFactory, Color color)
        {
            _uiElementFactory = uiElementFactory ?? throw new ArgumentNullException(nameof(uiElementFactory));
            _color = color;
        }

        public IText Create(ITransform transform)
        {
            IText text = new Text(_uiElementFactory.Create(transform), _font);
            text.SwitchColor(_color);
            return text;
        }
    }
}
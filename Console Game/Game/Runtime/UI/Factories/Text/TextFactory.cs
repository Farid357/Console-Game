using System;

namespace Console_Game.UI
{
    public sealed class TextFactory : ITextFactory
    {
        private readonly ICanvas _canvas;

        public TextFactory(ICanvas canvas)
        {
            _canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
        }

        public IText Create()
        {
            IText text = new Text(new UiElement(new UiElementView()));
            _canvas.Add(text);
            return text;
        }
    }
}
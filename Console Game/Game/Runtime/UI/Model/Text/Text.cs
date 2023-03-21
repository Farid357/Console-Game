using System;
using System.Drawing;

namespace Console_Game.UI
{
    [Serializable]
    public sealed class Text : IText
    {
        private readonly IUiElement _uiElement;
        private readonly Font _font;
        private readonly Graphics _graphics;
        
        public Text(IUiElement uiElement, Font font)
        {
            _uiElement = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
            _font = font ?? throw new ArgumentNullException(nameof(font));
        }
        
        public bool IsEnabled => _uiElement.IsEnabled;
        
        public ITransform Transform => _uiElement.Transform;

        public Color Color { get; private set; } = Color.Black;
        
        public string Line { get; private set; }

        public void Visualize(string line)
        {
            Line = line;
            var solidBrush = new SolidBrush(Color);
            _graphics.DrawString(Line, _font, solidBrush, 1, 2);
        }

        public void SwitchColor(Color color)
        {
            Color = color;
            Visualize(Line);
        }

        public void Enable()
        {
            _uiElement.Enable();
        }

        public void Disable() => _uiElement.Disable();
    }
}
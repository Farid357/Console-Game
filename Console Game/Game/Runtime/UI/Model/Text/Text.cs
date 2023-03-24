using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;

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
            Vector2 position = Transform.Position;
            _graphics.DrawString(Line, _font, solidBrush, position.X, position.Y);
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
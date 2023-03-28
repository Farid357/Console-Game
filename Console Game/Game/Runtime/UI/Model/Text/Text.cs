using System;
using System.Drawing;
using System.Numerics;

namespace ConsoleGame.UI
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
            Draw(Line);
        }

        public void SwitchColor(Color color)
        {
            Color = color;
            Visualize(Line);
        }

        public void Enable()
        {
            _uiElement.Enable();
            Draw(Line);
        }

        public void Disable()
        {
            _uiElement.Disable();
            Draw(string.Empty);
        }

        private void Draw(string line)
        {
            var solidBrush = new SolidBrush(Color);
            Vector3 position = Transform.Position;
          //  _graphics.DrawString(line, _font, solidBrush, position.X, position.Y);
        }
    }
}
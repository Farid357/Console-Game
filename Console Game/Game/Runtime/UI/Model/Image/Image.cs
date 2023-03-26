using System;
using System.Drawing;
using ConsoleGame.Tools;

namespace ConsoleGame.UI
{
    [Serializable]
    public sealed class Image : IImage
    {
        private readonly IUiElement _uiElement;
        private readonly Graphics _graphics;
        private readonly Bitmap _bitmap;

        public Image(IUiElement uiElement, Bitmap bitmap)
        {
            _uiElement = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
            _bitmap = bitmap ?? throw new ArgumentNullException(nameof(bitmap));
            _graphics = Graphics.FromImage(_bitmap);
        }
        
        public ITransform Transform => _uiElement.Transform;

        public Color Color { get; private set; }
      
        public bool IsEnabled => _uiElement.IsEnabled;

        public void Draw()
        {
            Point position = Transform.Position.ToPoint();
            _graphics.DrawImage(_bitmap, position);
        }
        
        public void Enable()
        {
            _uiElement.Enable();
        }
        
        public void Disable()
        {
            _uiElement.Disable();
            _bitmap.Dispose();
        }

        public void SwitchColor(Color color)
        {
            Color = color;
            _bitmap.SwitchColor(color);
            Draw();
        }
    }
}
using System;

namespace ConsoleGame.UI
{
    public sealed class Bar : IBar
    {
        private readonly IImage _image;

        public Bar(IImage image)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public float Size { get; private set; }
        
        public bool IsEnabled => _image.IsEnabled;

        public ITransform Transform => _image.Transform;
        
        public void Enable()
        {
            _image.Enable();
        }

        public void Disable()
        {
           _image.Disable();
        }


        public void SetSize(float size)
        {
            Size = size;
            //TODO
        }
    }
}
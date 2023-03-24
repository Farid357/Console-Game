using System;

namespace Console_Game.UI
{
    public sealed class ScrollViewWithRendering : IScrollViewWithRendering
    {
        private readonly IScrollView _scrollView;

        public ScrollViewWithRendering(IScrollView scrollView, IImage image)
        {
            _scrollView = scrollView ?? throw new ArgumentNullException(nameof(scrollView));
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }
        
        public IImage Image { get; }

        public bool IsEnabled => _scrollView.IsEnabled;

        public ITransform Transform => _scrollView.Transform;

        public void Enable()
        {
            _scrollView.Enable();
            Image.Enable();
        }

        public void Disable()
        {
            _scrollView.Disable();
            Image.Disable();
        }

        public void Put(IUiElement uiElement)
        {
            _scrollView.Put(uiElement);
        }

        public void Remove(IUiElement uiElement)
        {
            _scrollView.Remove(uiElement);
        }
    }
}
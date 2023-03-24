using System;

namespace Console_Game.UI
{
    public sealed class ScrollViewWithRenderingFactory : IScrollViewWithRenderingFactory
    {
        private readonly IScrollViewFactory _scrollViewFactory;
        private readonly IImageFactory _imageFactory;

        public ScrollViewWithRenderingFactory(IScrollViewFactory scrollViewFactory, IImageFactory imageFactory)
        {
            _scrollViewFactory = scrollViewFactory ?? throw new ArgumentNullException(nameof(scrollViewFactory));
            _imageFactory = imageFactory ?? throw new ArgumentNullException(nameof(imageFactory));
        }

        public IScrollViewWithRendering Create()
        {
            IScrollView scrollView = _scrollViewFactory.Create();
            IImage image = _imageFactory.Create(scrollView.Transform);
            return new ScrollViewWithRendering(scrollView, image);
        }
    }
}
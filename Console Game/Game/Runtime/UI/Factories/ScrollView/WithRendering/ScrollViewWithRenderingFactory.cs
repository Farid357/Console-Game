using System;

namespace Console_Game.UI
{
    public sealed class ScrollViewWithRenderingFactory : IScrollViewWithRenderingFactory
    {
        private readonly IScrollViewFactory _scrollViewFactory;

        public ScrollViewWithRenderingFactory(IScrollViewFactory scrollViewFactory)
        {
            _scrollViewFactory = scrollViewFactory ?? throw new ArgumentNullException(nameof(scrollViewFactory));
        }

        public IScrollViewWithRendering Create(IImage image)
        {
            IScrollView scrollView = _scrollViewFactory.Create();
            return new ScrollViewWithRendering(scrollView, image);
        }
    }
}
using System;

namespace ConsoleGame.UI
{
    public sealed class ScrollViewFactory : IScrollViewFactory
    {
        private readonly ICanvas _canvas;
        private readonly ITransform _transform;
        private readonly ILayoutGroup _layout;

        public ScrollViewFactory(ITransform transform, ICanvas canvas, ILayoutGroup layout)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
            _layout = layout ?? throw new ArgumentNullException(nameof(layout));
        }

        public IScrollView Create()
        {
            IScrollView scrollView = new ScrollView(_transform, _layout);
            _canvas.Add(scrollView);
            return scrollView;
        }
    }
}
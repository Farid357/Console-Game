using System;
using System.Collections.Generic;

namespace Console_Game.UI
{
    public sealed class ScrollView : IScrollView
    {
        private readonly ILayoutGroup _layoutGroup;
        private readonly List<IUiElement> _elements;
        
        public ScrollView(ITransform transform, ILayoutGroup layoutGroup)
        {
            Transform = transform ?? throw new ArgumentNullException(nameof(transform));
            _layoutGroup = layoutGroup ?? throw new ArgumentNullException(nameof(layoutGroup));
            _elements = new List<IUiElement>();
        }

        public bool IsEnabled { get; private set; }

        public ITransform Transform { get; }

        public void Put(IUiElement uiElement)
        {
            _elements.Add(uiElement);
            _layoutGroup.Add(uiElement);
        }

        public void Remove(IUiElement uiElement)
        {
            _elements.Remove(uiElement);
            _layoutGroup.Remove(uiElement);
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }
    }
}
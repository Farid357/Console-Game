using System;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class InventorySlotView : IUiElement, IInventorySlotView
    {
        private readonly IText _text;
        private IImage _icon;

        public InventorySlotView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public bool IsEnabled => _text.IsEnabled;

        public ITransform Transform => _text.Transform;
        
        public void Visualize(IInventoryItemViewData viewData, int count)
        {
            _text.Visualize(count > 1 ? $"item: {viewData.Name}  has count: {count}" : $"item: {viewData.Name}");
            _icon = viewData.Icon;
            _icon.Draw();
            _icon.Enable();
        }

        public void Enable()
        {
            _text.Enable();
            _icon.Enable();
        }

        public void Disable()
        {
            _text.Disable();
            _icon.Disable();
        }
    }
}
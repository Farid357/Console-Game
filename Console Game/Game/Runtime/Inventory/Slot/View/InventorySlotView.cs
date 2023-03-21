using System;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class InventorySlotView : IInventorySlotView
    {
        private readonly IText _text;

        public InventorySlotView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void Visualize(IInventoryItemViewData viewData, int count)
        {
            if (count > 1)
            {
               _text.Visualize($"item: {viewData.Name}  has count: {count}");
            }
            
            else
            {
               _text.Visualize($"item: {viewData.Name}");
            }
        }
    }
}
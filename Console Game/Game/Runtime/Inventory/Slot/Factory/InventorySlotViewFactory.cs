using System;
using System.Drawing;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class InventorySlotViewFactory : IInventorySlotViewFactory
    {
        private readonly ITextFactory _textFactory;

        public InventorySlotViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IInventorySlotView Create()
        {
            var font = new Font("Arial", 14);
            IText text = _textFactory.Create(new Transform(), font, Color.Azure);
            var slotView = new InventorySlotView(text);
            return slotView;
        }
    }
}
using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public class InventoryItemViewData : IInventoryItemViewData
    {
        public InventoryItemViewData(string name, IImage icon)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }

        public string Name { get; }

        public IImage Icon { get; }
    }
}
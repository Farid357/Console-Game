using System;
using Console_Game.UI;

namespace Console_Game
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
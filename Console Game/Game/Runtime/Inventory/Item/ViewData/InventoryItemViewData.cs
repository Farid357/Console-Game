using System;
using System.Drawing;

namespace Console_Game
{
    public class InventoryItemViewData : IInventoryItemViewData
    {
        public InventoryItemViewData(string name, string description, Graphics icon)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }

        public string Name { get; }
        public string Description { get; }

        public Graphics Icon { get; }
    }
}
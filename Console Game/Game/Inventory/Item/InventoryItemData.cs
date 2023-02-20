using System;
using System.Drawing;

namespace Console_Game
{
    public class InventoryItemData : IInventoryItemData
    {
        public InventoryItemData(string name, Graphics icon)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }

        public string Name { get; }
        
        public Graphics Icon { get; }
    }
}
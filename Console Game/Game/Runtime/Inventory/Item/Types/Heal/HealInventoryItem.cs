using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class HealInventoryItem : IHealInventoryItem
    {

        public HealInventoryItem(IInventoryItemViewData viewData, int heal)
        {
            ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
            Heal = heal.ThrowIfLessThanOrEqualsToZeroException();
        }
        
        public int Heal { get; }
        
        public IInventoryItemViewData ViewData { get; }
    }
}
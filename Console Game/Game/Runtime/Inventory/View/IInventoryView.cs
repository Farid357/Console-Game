using System.Collections.Generic;

namespace Console_Game
{
    public interface IInventoryView<TItem>
    {
        void Visualize(IEnumerable<IInventorySlot<TItem>> slots);
    }
}
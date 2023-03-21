using System.Collections.Generic;

namespace Console_Game.Tests.Inventory
{
    public sealed class DummyInventoryView<T> : IInventoryView<T>
    {
        public void Visualize(IEnumerable<IInventorySlot<T>> slots)
        {
            
        }
    }
}
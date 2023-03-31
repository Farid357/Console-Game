using ConsoleGame.Tests.Inventory;

namespace ConsoleGame
{
    public sealed class InventoryViewFactory<TItem> : IInventoryViewFactory<TItem>
    {
        public IInventoryView<TItem> Create()
        {
            return new DummyInventoryView<TItem>();
        }
    }
}
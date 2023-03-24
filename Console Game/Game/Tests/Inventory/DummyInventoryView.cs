namespace Console_Game.Tests.Inventory
{
    public sealed class DummyInventoryView<T> : IInventoryView<T>
    {
        public void Add(IInventorySlot<T> slot)
        {
            
        }

        public void Drop(IInventorySlot<T> slot)
        {
        }
    }
}
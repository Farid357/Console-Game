namespace Console_Game.Tests.Inventory
{
    public sealed class DummySlot<T> : IInventorySlot<T>
    {
        public T Item { get; }
        
        public int ItemsCount { get; }
        
        public bool CanTake(int itemsCount) => true;

        public bool CanAdd(int itemsCount) => true;

        public void Add(int itemsCount)
        {
        }

        public void Take(int itemsCount)
        {
        }
    }
}
namespace ConsoleGame
{
    public interface IInventoryView<in TItem>
    {
        void Add(IInventorySlot<TItem> slot);
        
        void Drop(IInventorySlot<TItem> slot);
    }
}
namespace Console_Game.Inventory
{
    public interface IInventoryItemSelector<in TItem> where TItem : IInventoryItem
    {
        void Select(TItem item);
    }
}
namespace ConsoleGame
{
    public interface IInventoryViewFactory<in TItem>
    {
        IInventoryView<TItem> Create();
    }
}
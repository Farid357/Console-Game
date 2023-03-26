namespace ConsoleGame.Inventory
{
    public interface IInventoryItemSelectingInput<out TItem>
    {
        bool IsUsing();
        
        TItem InputItem { get; }
    }
}
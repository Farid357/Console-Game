namespace Console_Game.Inventory
{
    public interface IInventoryItemSelectingInput<out TItem>
    {
        bool IsUsing();
        
        TItem InputItem { get; }
    }
}
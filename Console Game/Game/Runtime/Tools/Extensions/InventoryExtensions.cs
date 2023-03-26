namespace ConsoleGame.Tools
{
    public static class InventoryExtensions
    {
        public static bool ContainsSlot<T>(this IReadOnlyInventory<T> inventory, int index)
        {
            return inventory.Slots.Count > index;
        }
    }
}
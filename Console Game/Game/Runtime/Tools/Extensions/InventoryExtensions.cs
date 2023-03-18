namespace Console_Game.Tools
{
    public static class InventoryExtensions
    {
        public static bool ContainsSlot<T>(this IReadOnlyInventory<T> inventory, int index) where T : IInventoryItem
        {
            return inventory.Slots.Count > index;
        }
    }
}
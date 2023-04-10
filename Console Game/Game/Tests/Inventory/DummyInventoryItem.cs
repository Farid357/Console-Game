namespace ConsoleGame.Tests.Physics
{
    public sealed class DummyInventoryItem : IInventoryItem
    {
        public IInventoryItemViewData ViewData { get; }
        public bool IsSelected { get; }
        
        public void Select()
        {
            
        }

        public void Unselect()
        {
        }
    }
}
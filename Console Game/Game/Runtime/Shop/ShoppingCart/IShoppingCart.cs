namespace Console_Game.Shop
{
    public interface IShoppingCart : IReadOnlyShoppingCart
    {
        void Add(IGood good);

        void Remove(IGood good);
    }
}
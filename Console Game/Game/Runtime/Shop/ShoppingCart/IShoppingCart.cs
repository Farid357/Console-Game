namespace ConsoleGame.Shop
{
    public interface IShoppingCart : IReadOnlyShoppingCart
    {
        void Add(IGood good);

        void Remove(IGood good);
    }
}
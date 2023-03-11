namespace Console_Game.Shop
{
    public interface IShoppingCartView
    {
        void Add(IGood good);

        void Remove(IGood good);

        void Visualize(int totalCost);
    }
}
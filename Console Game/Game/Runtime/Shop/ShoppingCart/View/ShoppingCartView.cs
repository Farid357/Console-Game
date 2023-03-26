using System;

namespace ConsoleGame.Shop
{
    public sealed class ShoppingCartView : IShoppingCartView
    {
        public void Add(IGood good)
        {
            Console.WriteLine($"Add good {good.Name}, cost: {good.Cost}");
        }

        public void Remove(IGood good)
        {
            Console.WriteLine($"Remove good {good.Name}, cost: {good.Cost}");
        }

        public void Visualize(int totalCost)
        {
            Console.WriteLine($"Total cost {totalCost}");
        }
    }
}
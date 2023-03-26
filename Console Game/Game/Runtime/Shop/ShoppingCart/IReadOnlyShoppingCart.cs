using System.Collections.Generic;

namespace ConsoleGame.Shop
{
    public interface IReadOnlyShoppingCart
    {
        IReadOnlyList<IGood> Goods { get; }
        
        int TotalCost();
    }
}
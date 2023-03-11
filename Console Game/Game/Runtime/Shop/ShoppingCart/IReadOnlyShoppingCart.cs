using System.Collections.Generic;

namespace Console_Game.Shop
{
    public interface IReadOnlyShoppingCart
    {
        IReadOnlyList<IGood> Goods { get; }
        
        int TotalCost();
    }
}
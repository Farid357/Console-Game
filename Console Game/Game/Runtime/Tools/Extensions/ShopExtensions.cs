using System;
using Console_Game.Shop;

namespace Console_Game.Tools
{
    public static class ShopExtensions
    {
        public static void Clear(this IShoppingCart shoppingCart)
        {
            if (shoppingCart.IsEmpty())
                throw new InvalidOperationException($"Shopping cart is empty!");

            for (var i = 0; i < shoppingCart.Goods.Count; i++)
            {
                IGood good = shoppingCart.Goods[i];
                shoppingCart.Remove(good);
            }
        }

        public static bool IsEmpty(this IShoppingCart shoppingCart)
        {
            return shoppingCart.Goods.Count == 0;
        }
    }
}
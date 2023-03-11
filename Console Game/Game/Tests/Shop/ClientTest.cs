using Console_Game.Shop;
using Console_Game.Tools;
using NUnit.Framework;

namespace Console_Game.Tests.Shop
{
    [TestFixture]
    public sealed class ClientTest
    {
        [Test]
        public void BuyGoodsCorrectly()
        {
            const int money = 1000000;
            IWallet wallet = new Wallet(money, new WalletView());
            IShoppingCart shoppingCart = new ShoppingCart(new ShoppingCartView());
            IClient client = new Client(wallet, shoppingCart);
            const int goodCost = 10;
            shoppingCart.Add(new Good(goodCost, "Good"));
            client.BuyGoods();
            Assert.That(shoppingCart.IsEmpty());
            Assert.That(wallet.Money == money - goodCost);
        }
    }
}
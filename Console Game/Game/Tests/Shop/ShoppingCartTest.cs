using System.Linq;
using ConsoleGame.Tools;
using ConsoleGame.Shop;
using NUnit.Framework;

namespace ConsoleGame.Tests.Shop
{
    [TestFixture]
    public sealed class ShoppingCartTest
    {
        private IShoppingCart _shoppingCart;
        private IGood _good;
        
        [SetUp]
        public void SetUp()
        {
            _shoppingCart = new ShoppingCart(new ShoppingCartView());
            _good = new Good(10, string.Empty);
        }
        
        [Test]
        public void AddsCorrectly()
        {
            _shoppingCart.Add(_good);
            Assert.That(_shoppingCart.Goods.Contains(_good));
            Assert.That(_shoppingCart.Goods.Count == 1);
        }
        
        [Test]
        public void RemovesCorrectly()
        {
            AddsCorrectly();
            _shoppingCart.Remove(_good);
            Assert.That(_shoppingCart.IsEmpty() && _shoppingCart.Goods.Count == 0);
        }
    }
}
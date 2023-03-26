namespace ConsoleGame.Shop
{
    public interface IClient
    {
        bool EnoughMoney { get; }
        
        bool HasGoods { get; }

        void BuyGoods();
    }
}
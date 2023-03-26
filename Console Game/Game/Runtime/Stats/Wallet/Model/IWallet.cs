namespace ConsoleGame
{
    public interface IWallet : IReadOnlyWallet
    {
        void Put(int money);

        void Take(int money);
    }
}
namespace Console_Game
{
    public interface IWallet : IReadOnlyWallet
    {
        void Put(int money);

        void Take(int money);
    }
}
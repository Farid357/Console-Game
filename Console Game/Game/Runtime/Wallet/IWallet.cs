namespace Console_Game
{
    public interface IWallet
    {
        int Money { get; }

        bool CanTake(int money);

        void Put(int money);

        void Take(int money);
    }
}
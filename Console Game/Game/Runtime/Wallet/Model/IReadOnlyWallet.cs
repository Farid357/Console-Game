namespace Console_Game
{
    public interface IReadOnlyWallet
    {
        int Money { get; }

        bool CanTake(int money);
    }
}
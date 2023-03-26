namespace ConsoleGame
{
    public interface IReadOnlyWallet
    {
        int Money { get; }

        bool CanTake(int money);
    }
}
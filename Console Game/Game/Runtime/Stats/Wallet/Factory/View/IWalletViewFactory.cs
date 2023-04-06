namespace ConsoleGame
{
    public interface IWalletViewFactory
    {
        IWalletView Create(int money);
    }
}
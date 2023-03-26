namespace ConsoleGame.Tests
{
    public sealed class DummyWallet : IWallet
    {
        public int Money { get; }
        
        public bool CanTake(int money)
        {
            return false;
        }

        public void Put(int money)
        {
        }

        public void Take(int money)
        {
        }
    }
}
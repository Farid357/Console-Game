namespace ConsoleGame
{
    public sealed class BonusViewFactory : IBonusViewFactory
    {
        public IBonusView Create()
        {
            return new FakeBonusView();
        }
    }
}
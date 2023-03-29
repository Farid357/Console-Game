namespace ConsoleGame.UI
{
    public interface IBarFactory
    {
        IBar Create(ITransform transform, string imageFileName);
    }
}
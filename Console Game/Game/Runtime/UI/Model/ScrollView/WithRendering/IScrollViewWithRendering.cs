namespace ConsoleGame.UI
{
    public interface IScrollViewWithRendering : IScrollView
    {
        IImage Image { get; }
    }
}
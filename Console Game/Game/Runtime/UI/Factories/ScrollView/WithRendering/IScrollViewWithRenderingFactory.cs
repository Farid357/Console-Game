namespace ConsoleGame.UI
{
    public interface IScrollViewWithRenderingFactory
    {
        IScrollViewWithRendering Create(IImage image);
    }
}
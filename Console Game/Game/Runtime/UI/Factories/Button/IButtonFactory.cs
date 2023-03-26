namespace ConsoleGame.UI
{
    public interface IButtonFactory
    {
        IButton Create(IImage image, IButtonViewData viewData);
    }
}
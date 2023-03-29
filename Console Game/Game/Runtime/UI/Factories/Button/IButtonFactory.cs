namespace ConsoleGame.UI
{
    public interface IButtonFactory
    {
        IButton Create(ITransform transform, IButtonViewData viewData, string imageFileName);
    }
}
namespace Console_Game.UI
{
    public interface IButtonFactory
    {
        IButton Create(IImage image, IButtonViewData viewData);
    }
}
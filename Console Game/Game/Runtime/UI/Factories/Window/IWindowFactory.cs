namespace ConsoleGame.UI
{
    public interface IWindowFactory
    {
        IWindow Create(ITransform transform, string imageFileName);
    }
}
namespace ConsoleGame.UI
{
    public interface ICanvas : IUiElement
    {
        void Add(IUiElement element);

        void Remove(IUiElement element);
    }
}
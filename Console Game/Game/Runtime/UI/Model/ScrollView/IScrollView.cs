namespace ConsoleGame.UI
{
    public interface IScrollView : IUiElement
    {
        void Put(IUiElement uiElement);

        void Remove(IUiElement uiElement);
    }
}
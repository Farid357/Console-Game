namespace Console_Game.UI
{
    public interface ILayoutGroup
    {
        void Add(IReadOnlyUiElement uiElement);

        void Remove(IReadOnlyUiElement element);
    }
}
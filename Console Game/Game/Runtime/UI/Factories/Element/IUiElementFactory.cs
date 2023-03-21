namespace Console_Game.UI
{
    public interface IUiElementFactory
    {
        IUiElement Create(ITransform transform);
    }
}
namespace ConsoleGame.UI
{
    public interface IUiElementFactory
    {
        IUiElement Create(ITransform transform);
    }
}
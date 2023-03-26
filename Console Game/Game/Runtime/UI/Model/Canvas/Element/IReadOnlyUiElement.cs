namespace ConsoleGame.UI
{
    public interface IReadOnlyUiElement
    {
        bool IsEnabled { get; }
       
        ITransform Transform { get; }
    }
}
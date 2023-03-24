namespace Console_Game.UI
{
    public interface IReadOnlyUiElement
    {
        bool IsEnabled { get; }
       
        ITransform Transform { get; }
    }
}
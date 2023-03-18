namespace Console_Game.UI
{
    public interface IText : IUiElement
    {
        string Value { get; }
        
        void Visualize(string line);
    }
}
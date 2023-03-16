namespace Console_Game.UI
{
    public interface IText
    {
        string Value { get; }
        
        void Visualize(string value);
    }
}
namespace ConsoleGame.UI
{
    public interface IOnlyVisualizeText
    {
        string Line { get; }
        
        void Visualize(string line);
    }
}
namespace ConsoleGame.UI
{
    public interface IBar : IUiElement
    {
        float Size { get; }
        
        void SetSize(float size);
    }
}
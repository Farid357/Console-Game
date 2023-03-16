namespace Console_Game.UI
{
    public interface IWindow : IUiElement
    {
        bool IsOpen { get; }

        void Open();

        void Close();
    }
}
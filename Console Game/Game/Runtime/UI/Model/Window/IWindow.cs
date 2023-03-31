namespace ConsoleGame.UI
{
    public interface IWindow
    {
        bool IsOpen { get; }

        void Open();

        void Close();
    }
}
namespace Console_Game.UI
{
    public interface IWindow
    {
        bool IsOpen { get; }

        void Open();

        void Close();
    }
}
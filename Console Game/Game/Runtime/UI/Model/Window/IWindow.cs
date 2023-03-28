namespace ConsoleGame.UI
{
    public interface IWindow
    {
        bool IsOpen { get; }

        void Open();

        void Close();
    }

    public class FakeWindow : IWindow
    {
        public bool IsOpen { get; }
        public void Open()
        {
            
        }

        public void Close()
        {
        }
    }
}
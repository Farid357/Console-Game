namespace Console_Game.UI
{
    public interface IUiElement
    {
        bool IsEnabled { get; }
       
        void Enable();

        void Disable();
    }
}
namespace Console_Game.Shop
{
    public interface IButton
    {
        bool IsEnabled { get; }
        
        void Press();

        void Enable();
        
        void Disable();
    }
}
namespace ConsoleGame.UI
{
    public interface IUiElement : IReadOnlyUiElement
    {
        void Enable();

        void Disable();

    }
}
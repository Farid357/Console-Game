namespace Console_Game
{
    public interface IPause : IReadOnlyPause
    {
        void Enable();

        void Disable();
    }
}
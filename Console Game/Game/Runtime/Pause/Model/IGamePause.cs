namespace ConsoleGame
{
    public interface IGamePause : IReadOnlyGamePause
    {
        void Enable();

        void Disable();
    }
}
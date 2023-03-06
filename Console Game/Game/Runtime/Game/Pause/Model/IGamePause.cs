namespace Console_Game
{
    public interface IGamePause : IReadOnlyGamePause
    {
        void Enable();

        void Disable();
    }
}
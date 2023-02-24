namespace Console_Game
{
    public interface IAdjustableMovement : IMovement
    {
        bool IsActive { get; }

        void Continue();

        void Stop();
    }
}
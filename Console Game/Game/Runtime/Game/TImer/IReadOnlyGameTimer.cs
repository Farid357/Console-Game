namespace Console_Game.Loop
{
    public interface IReadOnlyGameTimer
    {
        bool IsActive { get; }

        long ElapsedMilliseconds { get; }
    }
}
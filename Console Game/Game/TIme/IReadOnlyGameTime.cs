namespace Console_Game.Loop
{
    public interface IReadOnlyGameTime
    {
        bool IsActive { get; }

        long ElapsedMilliseconds { get; }
        
        long TimeBetweenFrames { get; }
    }
}
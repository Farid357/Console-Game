namespace Console_Game.Loop
{
    public interface IReadOnlyGameTime
    {
        bool IsActive { get; }

        float Delta { get; }
    }
}
namespace Console_Game.Loop
{
    public interface IFps : IReadOnlyFps
    {
        int Calculate(float deltaTime, long elapsedMilliseconds);
    }
}
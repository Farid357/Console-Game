namespace Console_Game.LoadSystem
{
    public interface IAsyncScene : IScene
    {
        float LoadingProgress { get; }
    }
}
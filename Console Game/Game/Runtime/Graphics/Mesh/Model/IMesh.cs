namespace ConsoleGame.Rendering
{
    public interface IMesh : IReadOnlyGameObject
    {
        IMeshData Data { get; }

        void Destroy();
    }
}
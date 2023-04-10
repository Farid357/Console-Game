namespace ConsoleGame.Rendering
{
    public interface IRenderer : IReadOnlyGameObject
    {
        void Render(float deltaTime);
    }
}
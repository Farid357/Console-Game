namespace ConsoleGame.Rendering
{
    public interface IRenderersGroup
    {
        void Add(IRenderer renderer);
        
        void Remove(IRenderer renderer);
    }
}
namespace ConsoleGame.UI
{
    public interface IImageFactory
    {
        IImage Create(ITransform transform, string imageFileName);
    }
}
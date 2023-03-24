namespace Console_Game.UI
{
    public interface IImageFactory
    {
        IImage Create(ITransform transform, string imageFileName);
    }
}
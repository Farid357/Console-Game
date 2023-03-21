namespace Console_Game.UI
{
    public interface IButtonFactory
    {
        IButton Create(ITransform transform);
    }
}
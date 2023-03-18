namespace Console_Game
{
    public interface IReadOnlyGameObject
    {
        ITransform Transform { get; }
        
        bool IsActive { get; }
        
        bool IsDestroyed { get; }
    }
}
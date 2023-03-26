namespace ConsoleGame
{
    public interface ICircleMovement
    {
        bool IsActive { get; }
        
        IReadOnlyTransform Transform { get; }
        
        void Stop();
        
        void Continue();
        
    }
}
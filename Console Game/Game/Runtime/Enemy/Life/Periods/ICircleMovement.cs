namespace Console_Game
{
    public interface ICircleMovement
    {
        bool IsActive { get; }
        
        IReadOnlyTransform Transform { get; }
        
        void Stop();
        
        void Continue();
        
    }
}
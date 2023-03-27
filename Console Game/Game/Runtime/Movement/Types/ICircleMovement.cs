namespace ConsoleGame
{
    public interface ICircleMovement
    {
        IReadOnlyTransform Transform { get; }
        
        void Stop();
        
        void Continue();

        void Move();
    }
}
namespace ConsoleGame
{
    public interface IIndependentMovement
    {
        IReadOnlyTransform Transform { get; }
        
        void Move();
    }
}
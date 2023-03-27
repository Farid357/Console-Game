namespace ConsoleGame
{
    public interface IAdjustableMovement : IMovement
    {
        float Speed { get; }

        void IncreaseSpeed(float speed);

        void DecreaseSpeed(float speed);
    }
}
namespace ConsoleGame
{
    public interface ICircleMovement : IIndependentMovement
    {
        void Stop();
        
        void Continue();
    }
}
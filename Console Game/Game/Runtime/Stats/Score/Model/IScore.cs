namespace ConsoleGame
{
    public interface IScore : IReadOnlyScore
    {
        void Raise(int count);
    }
}
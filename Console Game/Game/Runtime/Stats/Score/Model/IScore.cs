namespace ConsoleGame
{
    public interface IScore
    {
        int Count { get; }

        void Raise(int count);
    }
}
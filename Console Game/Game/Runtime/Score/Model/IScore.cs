namespace Console_Game
{
    public interface IScore
    {
        int Count { get; }

        void Raise(int count);
    }
}
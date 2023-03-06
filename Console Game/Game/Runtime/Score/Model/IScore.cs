namespace Console_Game.Score
{
    public interface IScore
    {
        int Count { get; }

        void Raise(int count);
    }
}
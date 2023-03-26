namespace ConsoleGame
{
    public interface IReward
    {
        bool IsApplied { get; }

        void Apply();
    }
}
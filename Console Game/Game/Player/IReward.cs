namespace Console_Game
{
    public interface IReward
    {
        bool IsApplied { get; }

        void Apply();
    }
}
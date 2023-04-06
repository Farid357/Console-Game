namespace Console_Game
{
    public interface IReadOnlyBattery
    {
        float Amount { get; }
        
        bool IsDischarged { get; }
    }
}
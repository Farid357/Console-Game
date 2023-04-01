namespace ConsoleGame
{
    public interface ITimer : IReadOnlyTimer
    {
        void ResetTime();

        void IncreaseCooldown(float amount);
        
        void DecreaseCooldown(float amount);
        
    }
}
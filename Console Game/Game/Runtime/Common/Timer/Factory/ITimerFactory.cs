namespace ConsoleGame
{
    public interface ITimerFactory
    {
        ITimer Create(float cooldown);
    }
}
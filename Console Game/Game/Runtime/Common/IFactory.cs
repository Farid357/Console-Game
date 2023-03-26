namespace ConsoleGame
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
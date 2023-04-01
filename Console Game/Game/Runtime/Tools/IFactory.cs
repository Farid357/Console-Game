namespace ConsoleGame.Tools
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
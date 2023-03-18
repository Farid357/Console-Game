namespace Console_Game
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
namespace ConsoleGame.GameLoop
{
    public interface IGameObjectsGroup
    {
        void Add(IGameObject gameObject);

        void Remove(IGameObject gameObject);
    }
}
namespace ConsoleGame.Loop
{
    public interface IGameObjectsGroup
    {
        void Add(IGameObject gameObject);

        void Remove(IGameObject gameObject);
    }
}
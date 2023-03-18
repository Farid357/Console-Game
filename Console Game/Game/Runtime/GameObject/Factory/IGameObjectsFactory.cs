namespace Console_Game
{
    public interface IGameObjectsFactory
    {
        IGameObject Create(ITransform transform);
    }
}
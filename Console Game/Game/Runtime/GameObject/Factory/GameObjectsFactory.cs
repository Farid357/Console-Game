namespace Console_Game
{
    public sealed class GameObjectsFactory : IGameObjectsFactory
    {
        public IGameObject Create(ITransform transform)
        {
            return new GameObject(transform, new GameObjectView());
        }
    }
}
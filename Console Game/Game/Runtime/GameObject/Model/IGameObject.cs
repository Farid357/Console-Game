namespace Console_Game
{
    public interface IGameObject : IReadOnlyGameObject
    {
        void Enable();

        void Disable();

        void Destroy();
    }
}
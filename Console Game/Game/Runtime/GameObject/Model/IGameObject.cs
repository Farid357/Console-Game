namespace Console_Game
{
    public interface IGameObject
    {
        bool IsActive { get; }
        
        void Enable();

        void Disable();

        void Destroy();
    }
}
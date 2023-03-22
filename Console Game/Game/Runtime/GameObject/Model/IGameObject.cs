namespace Console_Game
{
    public interface IGameObject : IGameLoopObject
    {
        bool IsActive { get; }
        
        // void Enable();
        //
        // void Disable();

        void Destroy();
    }
}
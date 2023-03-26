namespace ConsoleGame.LoadSystem
{
    public interface ISceneLoadingView
    {
        void Enable();
        
        void Visualize(float progress);

        void Disable();
    }
}
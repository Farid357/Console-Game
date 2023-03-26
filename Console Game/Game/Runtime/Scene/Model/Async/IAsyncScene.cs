using System.Threading.Tasks;

namespace ConsoleGame.LoadSystem
{
    public interface IAsyncScene
    {
        float LoadingProgress { get; }
        
        bool IsLoaded { get; }
        
        Task Load();

        Task Unload();
    }
}
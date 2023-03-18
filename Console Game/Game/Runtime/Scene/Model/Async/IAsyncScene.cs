using System.Threading.Tasks;

namespace Console_Game.LoadSystem
{
    public interface IAsyncScene
    {
        float LoadingProgress { get; }
        
        bool IsLoaded { get; }
        
        Task Load();

        Task Unload();
    }
}
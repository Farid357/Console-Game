using System.Threading.Tasks;

namespace Console_Game.LoadSystem
{
    public interface IScene
    {
        bool IsLoaded { get; }
        
        Task Load();

        Task Unload();
    }
}
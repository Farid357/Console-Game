using System.Threading.Tasks;

namespace Console_Game.LoadSystem
{
    public interface IScreen
    {
        Task FadeIn();

        Task FadeOut();
    }
}
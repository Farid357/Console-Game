using System.Threading.Tasks;

namespace ConsoleGame.LoadSystem
{
    public interface IScreen
    {
        Task FadeIn();

        Task FadeOut();
    }
}
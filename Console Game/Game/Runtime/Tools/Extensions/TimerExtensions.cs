using System.Threading.Tasks;

namespace Console_Game.Tools
{
    public static class TimerExtensions
    {
        public static async Task End(this ITimer timer)
        {
            while (timer.IsEnded == false)
                await Task.Yield();
        }
    }
}
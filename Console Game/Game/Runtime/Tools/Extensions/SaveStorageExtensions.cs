using ConsoleGame.SaveSystem;
using ConsoleGame.Stats;

namespace ConsoleGame.Tools
{
    public static class SaveStorageExtensions
    {
        public static T LoadOrDefault<T>(this ISaveStorage<T> storage, T defaultValue = default)
        {
            return storage.HasSave() ? storage.Load() : defaultValue;
        }

        public static void Visualize(this ILevel level)
        {
            level.Increase(0);
        }
    }
}
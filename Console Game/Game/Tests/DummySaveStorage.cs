using ConsoleGame.SaveSystem;

namespace ConsoleGame.Tests
{
    public sealed class DummySaveStorage<T> : ISaveStorage<T>
    {
        public bool HasSave() => false;

        public void DeleteSave()
        {
        }

        public T Load()
        {
            return default;
        }

        public void Save(T value)
        {
        }
    }
}
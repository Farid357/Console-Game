using System;
using ConsoleGame.SaveSystem;

namespace ConsoleGame.Shop
{
    public sealed class SaveGood<TType> : IGood
    {
        private readonly IGood _good;
        private readonly ISaveStorage<TType> _saveStorage;
        private readonly TType _type;
        
        public SaveGood(IGood good, ISaveStorage<TType> saveStorage, TType type)
        {
            _good = good ?? throw new ArgumentNullException(nameof(good));
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
            _type = type;
        }

        public string Name => _good.Name;

        public int Cost => _good.Cost;

        public void Use()
        {
            _good.Use();
            _saveStorage.Save(_type);
        }
    }
}
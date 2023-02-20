using System;
using System.Collections.Generic;

namespace Console_Game.Loop
{
    public sealed class GameUpdate : IGameUpdate, IUpdateable
    {
        private readonly List<IUpdateable> _updateables;

        public GameUpdate(List<IUpdateable> updateables)
        {
            _updateables = updateables ?? throw new ArgumentNullException(nameof(updateables));
        }

        public GameUpdate() : this(new List<IUpdateable>())
        {
        }

        public IReadOnlyList<IUpdateable> Updateables => _updateables;

        public void Add(params IUpdateable[] updateables)
        {
            if (updateables == null)
                throw new ArgumentNullException(nameof(updateables));

            _updateables.AddRange(updateables);
        }

        public void Remove(params IUpdateable[] updateables)
        {
            if (updateables == null)
                throw new ArgumentNullException(nameof(updateables));

            foreach (var updateable in updateables)
            {
                _updateables.Remove(updateable);
            }
        }

        public void Update(float deltaTime)
        {
            _updateables.ForEach(updateable => updateable.Update(deltaTime));
        }
    }
}
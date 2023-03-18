using System;
using System.Collections.Generic;

namespace Console_Game
{
    public sealed class GameObjectViews : IGameObjectView, IGroup<IGameObjectView>
    {
        private readonly List<IGameObjectView> _views;

        public GameObjectViews(List<IGameObjectView> views)
        {
            _views = views ?? throw new ArgumentNullException(nameof(views));
        }

        public GameObjectViews() : this(new List<IGameObjectView>())
        {
            
        }

        public IReadOnlyList<IGameObjectView> All => _views;
     
        public void Destroy()
        {
            _views.ForEach(view => view.Destroy());
        }

        public void Enable()
        {
            _views.ForEach(view => view.Enable());
        }

        public void Disable()
        {
            _views.ForEach(view => view.Disable());
        }

        public void Remove(IGameObjectView instance)
        {
            _views.Remove(instance);
        }

        public void Add(IGameObjectView instance)
        {
            _views.Add(instance);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Rendering
{
    public sealed class Renderers : IRenderers
    {
        private readonly List<IRenderer> _all;

        public Renderers(List<IRenderer> all)
        {
            _all = all ?? throw new ArgumentNullException(nameof(all));
        }

        public Renderers() : this(new List<IRenderer>())
        {
        }

        public bool IsAlive => _all.Any(renderer => renderer.IsAlive);

        public void Render(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"All renderers are died!");

            foreach (var renderer in _all.Where(renderer => renderer.IsAlive))
            {
                renderer.Render(deltaTime);
            }
        }

        public void Add(IRenderer renderer)
        {
            if (renderer == null) 
                throw new ArgumentNullException(nameof(renderer));
            
            _all.Add(renderer);
        }

        public void Remove(IRenderer renderer)
        {
            _all.Remove(renderer);
        }
    }
}
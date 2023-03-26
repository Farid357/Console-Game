using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleGame.LoadSystem
{
    public sealed class AsyncScenes : IAsyncScenes
    {
        private readonly List<IAsyncScene> _scenes;

        public AsyncScenes(List<IAsyncScene> scenes)
        {
            _scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
        }

        public AsyncScenes() : this(new List<IAsyncScene>())
        {
        }

        public float LoadingProgress => _scenes.Sum(scene => scene.LoadingProgress) / _scenes.Count;

        public bool IsLoaded => _scenes.All(scene => scene.IsLoaded);

        public async Task Load()
        {
            var tasks = new List<Task>();
            _scenes.ForEach(scene => tasks.Add(scene.Load()));
            await Task.WhenAll(tasks);
        }

        public async Task Unload()
        {
            var tasks = new List<Task>();
            _scenes.ForEach(scene => tasks.Add(scene.Unload()));
            await Task.WhenAll(tasks);
        }

        public void Add(IAsyncScene instance) => _scenes.Add(instance);

        public void Remove(IAsyncScene instance) => _scenes.Remove(instance);
        
    }
}
using System;
using System.Collections.Generic;
using Console_Game.Loop;

namespace Console_Game.Group
{
    public sealed class Group<T> : IGroup<T>
    {
        private readonly List<T> _objects;

        public Group(List<T> objects)
        {
            _objects = objects ?? throw new ArgumentNullException(nameof(objects));
        }

        public Group() : this(new List<T>())
        {
            
        }

        public IReadOnlyList<T> All => _objects;
        
        public void Add(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
            
            _objects.Add(instance);
        }

        public void Remove(T instance)
        {
            if (instance == null) 
                throw new ArgumentNullException(nameof(instance));
            
            _objects.Remove(instance);
        }
    }
}
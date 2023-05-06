using System;

namespace ConsoleGame.Rendering
{
    public sealed class MeshRenderer : IMeshRenderer
    {
        private readonly IMesh _mesh;

        public MeshRenderer(IMesh mesh)
        {
            _mesh = mesh ?? throw new ArgumentNullException(nameof(mesh));
        }

        public bool IsAlive => _mesh.IsAlive;

        public IMeshData Data => _mesh.Data;

        public void Render(float deltaTime)
        {
            if (!IsAlive)
                throw new Exception($"Renderer is destroyed! You can't render it!");
        }

        public void Destroy()
        {
            _mesh.Destroy();
        }
    }
}
using System;

namespace ConsoleGame
{
    public sealed class FakeEffect : IEffect
    {
        private readonly ITransform _transform;

        public FakeEffect(ITransform transform)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        public bool IsPlaying { get; }

        public void Play()
        {
            Console.WriteLine($"Effect played in point: {_transform.Position}");
        }

        public void Stop()
        {
            Console.WriteLine("Effect stopped!");
        }
    }
}
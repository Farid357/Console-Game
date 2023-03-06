using System;
using Console_Game.Tools;

namespace Console_Game
{
    public sealed class Score : IScore
    {
        private readonly IScoreView _view;

        public Score(IScoreView view, int count)
        {
            Count = count.ThrowIfLessThanZeroException();
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int Count { get; private set; }
        
        public void Raise(int count)
        {
            Count += count.ThrowIfLessThanZeroException();
            _view.Visualize(Count);
        }
    }
}
using System;
using System.Windows.Threading;

namespace TetrisEngine
{
    public partial class TetrisFE
    {
        public bool Playing => _tetrisTimer.IsEnabled;
        public void Play()
        {
            if(_activeShape == null)
                NextShape();
            _tetrisTimer.Play();
        }

        public void Pause()
        {
            _tetrisTimer.Pause();
        }
    }
}
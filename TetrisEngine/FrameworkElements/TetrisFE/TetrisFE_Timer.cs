using System;
using System.Windows.Threading;

namespace TetrisEngine
{
    public partial class TetrisFE
    {
        public bool Playing { get; private set; }
        public void Play()
        {
            if(_activeShape == null)
                NextShape();
            Playing = true;
            _timer.Start();
        }

        public void Pause()
        {
            Playing = false;
            _timer.Stop();
        }

        private DispatcherTimer _timer;

        private void TimerCtor()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,0,0,0,400);
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            MoveDown();
        }
    }
}
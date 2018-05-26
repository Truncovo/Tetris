using System;
using System.Windows.Media;
using System.Windows.Threading;

namespace TetrisEngine
{
    public interface ITetrisTimer
    {
        void Play();
        void Pause();
        void Pause(TimeSpan pauseTime);
        event EventHandler TetrisTick;
        bool IsEnabled { get; }

    }
    public class TetrisTimer : ITetrisTimer
    {
        private readonly DispatcherTimer _timer;
        public bool IsEnabled => _timer.IsEnabled;

        public TetrisTimer(TimeSpan timeSpan)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = timeSpan;

            _timer.Tick += OnTimerTick;
        }

        public event EventHandler TetrisTick;
        protected void OnTimerTick(object sender, EventArgs e)
        {
            TetrisTick?.Invoke(this,e);
        }

        public void Play()
        {
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void Pause(TimeSpan pauseTime)
        {
            
            Pause();

            var pauseTimer = new DispatcherTimer();
            pauseTimer.Interval = pauseTime;
            pauseTimer.Tick += (sender, args) =>
            {
                Play();
                (sender as DispatcherTimer).Stop();
            };
        }
    }
}

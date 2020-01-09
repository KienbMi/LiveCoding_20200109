using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EventDemo.Logic
{
    public class FastClock
    {
        private readonly DispatcherTimer _timer;
        private bool _isRunning;

        public event EventHandler<DateTime> OneMinuteIsOver;

        public DateTime CurrentTime { get; private set; }

        public bool IsRunning
        {
            get => _isRunning;
            //get { return _isRunning; }

            set
            {
                if (!_isRunning && value)
                {
                    _timer.Start();
                }
                else if(_isRunning && value == false)
                {
                    _timer.Stop();
                }

                _isRunning = value;
            }
        }

        public FastClock(DateTime currentTime)
        {
            CurrentTime = currentTime;
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            CurrentTime = CurrentTime.AddMinutes(1);
            OnOneMinuteIsOver(CurrentTime);
        }

        protected virtual void OnOneMinuteIsOver(DateTime time)
        {
            OneMinuteIsOver?.Invoke(this, time);
        }

    }
}

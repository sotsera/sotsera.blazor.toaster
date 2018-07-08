using System;
using System.Threading;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class TransitionTimer : IDisposable
    {
        private Action<decimal> Callback { get; }
        private Timer Timer { get; set; }
        private DateTime DueTime { get; set; }
        private int TotalDuration { get; set; }
        private int StepDuration { get; set; }

        public TransitionTimer(Action<decimal> callback)
        {
            Callback = callback;
            Timer = new Timer(TransitionCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        private void TransitionCallback(object state)
        {
            var milliseconds = (DueTime - DateTime.Now).TotalMilliseconds;
            var ratio = milliseconds / TotalDuration;

            var percentage = milliseconds <= 0 || ratio >= 0.99 ? 100m : Convert.ToDecimal((1 - ratio) * 100);

            Callback(percentage);
        }

        public void Start(int totalDuration)
        {
            Start(totalDuration, totalDuration);
        }

        public void Start(int totalDuration, int stepDuration)
        {
            DueTime = DateTime.Now.AddMilliseconds(totalDuration);
            TotalDuration = totalDuration;
            StepDuration = stepDuration;
            
            Step();
        }

        public void Step()
        {
            Timer?.Change(StepDuration, Timeout.Infinite);
        }

        public void Stop()
        {
            Timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Stop();
            Timer.Dispose();
            Timer = null;
        }
    }
}
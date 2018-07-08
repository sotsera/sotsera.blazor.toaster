using System;
using System.Threading;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToastTimer : IDisposable
    {
        private Timer Timer { get; set; }

        public void Start(int milliseconds) => Timer?.Change(milliseconds, Timeout.Infinite);
        public void Stop() => Timer?.Change(Timeout.Infinite, Timeout.Infinite);

        public ToastTimer(TimerCallback callback)
        {
            Timer = new Timer(callback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Stop();
            Timer.Dispose();
            Timer = null;
        }
    }
}
// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;

namespace Sotsera.Blazor.Toaster.Core
{
    public class TransitionTimer : IDisposable
    {
        private Action Callback { get; set; }
        private Timer Timer { get; set; }

        public TransitionTimer(Action callback)
        {
            Callback = callback;
            Timer = new Timer(TransitionCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start(int duration)
        {
            if (duration <= 0) Callback?.Invoke();
            else Timer?.Change(duration, Timeout.Infinite);
        }

        public void Stop()
        {
            Timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void TransitionCallback(object state)
        {
            Callback?.Invoke();
        }

        public void Dispose()
        {
            Stop();
            Timer.Dispose();
            Timer = null;
            Callback = null;
        }
    }
}
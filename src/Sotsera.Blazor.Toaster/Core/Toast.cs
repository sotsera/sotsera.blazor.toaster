// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core
{
    /// <summary>
    /// Represents an instance of a Toast
    /// It handles the user interactions and orchestrates the the state transitions
    /// </summary>
    public class Toast : IDisposable
    {
        private Timer Timer { get; }
        internal State State { get; }

        public string Title { get; }
        public IList<string> Messages { get; }
        public event Action<Toast> OnClose;
        public event Action OnUpdate;
        public ToastOptions Options => State.Options;

        internal Toast(string title, IList<string> messages, ToastOptions options)
        {
            Title = title;
            Messages = messages;
            State = new State(options);
            Timer = new Timer(TimerElapsed, null, Timeout.Infinite, Timeout.Infinite);
        }

        internal void Init() => TransitionTo(ToastState.Showing);

        internal void MouseEnter() => TransitionTo(ToastState.MouseOver);

        internal void MouseLeave()
        {
            if (State.ToastState.IsHiding()) return;
            if (State.Options.RequireInteraction && !State.UserHasInteracted) 
                TransitionTo(ToastState.Visible);
            else
                TransitionTo(ToastState.Hiding);
        }

        internal void Clicked(bool fromCloseIcon)
        {
            if (!fromCloseIcon)
            {
                // Execute the click action only if it's not from the close icon
                State.Options.Onclick?.Invoke(this);
                // If the close icon is show do not start the hiding transition
                if (State.Options.ShowCloseIcon) return;
            }

            State.UserHasInteracted = true;
            TransitionTo(ToastState.Hiding);
        }

        private void TransitionTo(ToastState state)
        {
            StopTimer();
            State.ToastState = state;
            var options = State.Options;

            if (state.IsShowing())
            {
                if (options.ShowTransitionDuration <= 0) TransitionTo(ToastState.Visible);
                else StartTimer(options.ShowTransitionDuration);
            }
            else if (state.IsVisible() && !options.RequireInteraction)
            {
                if (options.VisibleStateDuration <= 0) TransitionTo(ToastState.Hiding);
                else StartTimer(options.VisibleStateDuration);
            }
            else if (state.IsHiding())
            {
                if (options.HideTransitionDuration <= 0) OnClose?.Invoke(this);
                else StartTimer(options.HideTransitionDuration);
            }

            OnUpdate?.Invoke();
        }

        private void TimerElapsed(object state)
        {
            switch (State.ToastState)
            {
                case ToastState.Showing:
                    TransitionTo(ToastState.Visible);
                    break;
                case ToastState.Visible:
                    TransitionTo(ToastState.Hiding);
                    break;
                case ToastState.Hiding:
                    OnClose?.Invoke(this);
                    break;
            }
        }

        private void StartTimer(int duration)
        {
            if (duration <= 0) TimerElapsed(null);
            else Timer?.Change(duration, Timeout.Infinite);
        }

        private void StopTimer()
        {
            Timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            StopTimer();
            Timer.Dispose();
        }
    }
}


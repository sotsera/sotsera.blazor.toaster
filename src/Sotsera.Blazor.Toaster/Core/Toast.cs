// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an instance of a Toast
    /// It handles the user interactions and orchestrates the the state transitions
    /// </summary>
    public class Toast : IDisposable
    {
        private string AnimationId { get; }

        private bool UserHasInteracted { get; set; }

        private TransitionTimer Timer { get; }
        private TransitionState TransitionState { get; set; }
        private ToastState State { get; set; }

        public ToastOptions Options { get; }
        public string Title { get; }
        public string Message { get; }
        public event Action<Toast> OnClose;
        public event Action OnUpdate;

        public bool ShowProgressBar => Options.ShowProgressBar && State == ToastState.Visible;

        public string ContainerClass
        {
            get
            {
                var forceCursor = (Options.ShowCloseIcon ? "" : " force-cursor");
                return $"{Options.ToastClass} {Options.ToastTypeClass}{forceCursor}";
            }
        }

        public string ProgressBarStyle
        {
            get
            {
                var percentage = TransitionState.ProgressPercentage;
                var milliseconds = TransitionState.RemainingMilliseconds;
                return $"width: {percentage}; animation: {AnimationId} {milliseconds}ms;";
            }
        }

        public string AnimationStyle
        {
            get
            {
                switch (State)
                {
                    case ToastState.Showing:
                        var opacity = Options.MaximumOpacity;
                        var showDuration = Options.ShowTransitionDuration;
                        return $"opacity: {opacity}; animation: {showDuration}ms linear {AnimationId};";
                    case ToastState.Visible:
                        return $"opacity: {TransitionState.Opacity};";
                    case ToastState.Hiding:
                        var hideDuration = Options.HideTransitionDuration;
                        return $"opacity: 0; animation: {hideDuration}ms linear {AnimationId};";
                    default:
                        return string.Empty;
                }
            }
        }
        
        public string TransitionClass
        {
            get
            {
                var template = "@keyframes " + AnimationId + " {{from{{ {0}: {1}; }} to{{ {0}: {2}; }}}}";

                switch (State)
                {
                    case ToastState.Showing:
                        return string.Format(template, "opacity", 0, TransitionState.Opacity);
                    case ToastState.Hiding:
                        return string.Format(template, "opacity", TransitionState.Opacity, 0);
                    case ToastState.Visible:
                        return string.Format(template, "width", $"{TransitionState.ProgressPercentage}%", "0%");
                    default:
                        return string.Empty;
                }
            }
        }

        public Toast(string title, string message, ToastOptions options)
        {
            Title = title;
            Message = message;
            Options = options;

            AnimationId = $"toaster-{Guid.NewGuid()}";

            State = ToastState.Init;
            Timer = new TransitionTimer(TimerElapsed);
        }

        private void TimerElapsed()
        {
            switch (State)
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

        public void MouseEnter() => TransitionTo(ToastState.MouseOver);

        public void MouseLeave()
        {
            if (State == ToastState.Hiding) return;
            if (Options.RequireInteraction && !UserHasInteracted) return; 
            TransitionTo(ToastState.Hiding);
        }

        public void Clicked(bool fromCloseIcon)
        {
            Options.Onclick?.Invoke(this);

            if (fromCloseIcon || !Options.ShowCloseIcon)
            {
                UserHasInteracted = true;
                TransitionTo(ToastState.Hiding);
            }
        }

        public void EnsureInitialized()
        {
            if (State == ToastState.Init) TransitionTo(ToastState.Showing);
            else UpdateTransitionState();
        }

        private void UpdateTransitionState()
        {
            TransitionState = State == ToastState.Visible && Options.RequireInteraction
                ? TransitionState.ForRequiredInteraction(Options.MaximumOpacity)
                : new TransitionState(Timer, Options.MaximumOpacity);
        }

        private void TransitionTo(ToastState state)
        {
            Timer.Stop();
            State = state;
            
            switch (state)
            {
                case ToastState.Showing:
                    if (Options.ShowTransitionDuration <= 0) TransitionTo(ToastState.Visible);
                    else Timer.Start(Options.ShowTransitionDuration);
                    break;
                case ToastState.Visible:
                    if (Options.RequireInteraction)
                    {
                        TransitionState = TransitionState.ForRequiredInteraction(Options.MaximumOpacity);
                        OnUpdate?.Invoke();
                        return;
                    }
                    else if (Options.VisibleStateDuration < 0) TransitionTo(ToastState.Hiding);
                    else Timer.Start(Options.VisibleStateDuration);
                    break;
                case ToastState.Hiding:
                    if (Options.HideTransitionDuration <= 0)
                    {
                        OnClose?.Invoke(this);
                        return;
                    }
                    else Timer.Start(Options.HideTransitionDuration);
                    break;
                case ToastState.MouseOver:
                    break;
            }

            UpdateTransitionState();
            OnUpdate?.Invoke();
        }

        public void Dispose()
        {
            Timer.Dispose();
        }
    }
}


using System;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core
{
    public class Toast : IDisposable
    {
        public ToastState State { get; set; }
        private Opacity Opacity { get; set; }
        public decimal TransitionPercentage { get; set; }
        private TransitionTimer Timer { get; }

        public ToastOptions Options { get; }
        public string Title { get; }
        public string Message { get; }
        public event Action<Toast> OnClose;
        public event Action OnUpdate;
        
        public string ContainerClass => $"{Options.ToastClass} {Options.ToastTypeClass()}";
        public string ContainerStyle => $"opacity: {Opacity};";
        public string ProgressBarStyle => $"width: {100 - TransitionPercentage}%;";

        public Toast(string title, string message, ToastOptions options)
        {
            Title = title;
            Message = message;
            Options = options;
            
            State = ToastState.Init;
            Opacity = new Opacity(options.MaximumOpacity);
            Timer = new TransitionTimer(TimerElapsed);
        }

        private void TimerElapsed(decimal transitionPercentage)
        {
            TransitionPercentage = transitionPercentage;
            switch (State)
            {
                case ToastState.Showing:
                    Opacity.SetPercentage(transitionPercentage);
                    if(transitionPercentage < 100) Timer.Step();
                    else TransitionTo(ToastState.Visible);
                    break;
                case ToastState.Visible:
                    if (transitionPercentage < 100) Timer.Step();
                    else TransitionTo(ToastState.Hiding);
                    break;
                case ToastState.Hiding:
                    Opacity.SetPercentage(100 - transitionPercentage);
                    if (transitionPercentage < 100) Timer.Step();
                    else OnClose?.Invoke(this);
                    break;
            }
            
            OnUpdate?.Invoke();
        }

        public void MouseEnter() => TransitionTo(ToastState.MouseOver);
        public void MouseLeave()
        {
            if (State == ToastState.Hiding) return;
            TransitionTo(ToastState.Hiding);
        }

        public void Clicked(bool fromCloseIcon)
        {
            Options.Onclick?.Invoke(this);

            if (fromCloseIcon || !Options.ShowCloseIcon)
            {
                TransitionTo(ToastState.Hiding);
            }
        }

        public void EnsureInitialized()
        {
            if(State == ToastState.Init) TransitionTo(ToastState.Showing);
        }

        private void TransitionTo(ToastState state)
        {
            Timer.Stop();
            switch (state)
            {
                case ToastState.Showing:
                    State = ToastState.Showing;
                    Opacity.SetPercentage(0);
                    Timer.Start(Options.ShowTransitionDuration, Options.ShowStepDuration);
                    break;
                case ToastState.Visible:
                    State = ToastState.Visible;
                    Opacity.SetPercentage(100);
                    TransitionPercentage = 100;
                    Timer.Start(Options.VisibleStateDuration, Options.VisibleStepDuration);
                    break;
                case ToastState.Hiding:
                    State = ToastState.Hiding;
                    Opacity.SetPercentage(100);
                    Timer.Start(Options.HideTransitionDuration, Options.HideStepDuration);
                    break;
                case ToastState.MouseOver:
                    State = ToastState.MouseOver;
                    Opacity.SetPercentage(100);
                    break;
            }
        }

        public void Dispose()
        {
            Timer.Dispose();
        }
    }
}


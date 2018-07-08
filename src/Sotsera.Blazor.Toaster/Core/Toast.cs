using System;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core
{
    public class Toast : IDisposable
    {
        private ToastTimer Timer { get; }
        private decimal Opacity { get; set; } = 1;

        public event Action<Toast> OnClose;
        public event Action OnUpdate;
        public ToastType Type { get; }
        public ToastOptions Options { get; }
        public string Title { get; }
        public string Message { get; }
        
        public string ContainerClass => $"{Options.ToastClass} {Options.IconClass}";
        public string ContainerStyle => $"opacity: {Opacity};";

        public Toast(ToastType type, string title, string message, ToastOptions options)
        {
            Type = type;
            Title = title;
            Message = message;
            Options = options;

            Timer = new ToastTimer(state => TimerElapsed());
        }

        private void TimerElapsed()
        {

        }

        public void MouseEnter() => TransitionTo(ToastState.Visible);
        public void MouseLeave() => TransitionTo(ToastState.Hiding);

        public void Clicked()
        {
            if (Options.Onclick == null) return;

            Options.Onclick?.Invoke(this);
            TransitionTo(ToastState.Closing);
        }

        private void TransitionTo(ToastState state)
        {
            Console.WriteLine($"Transitioning to {state}");
            switch (state)
            {
                case ToastState.Clicked:
                    Options.Onclick?.Invoke(this);
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            Timer.Dispose();
        }
    }
}


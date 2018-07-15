using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToasterConfiguration
    {
        private bool _newestOnTop;
        private bool _preventDuplicates;
        private int _maxDisplayedToasts;
        private string _positionClass;

        internal event Action OnUpdate;

        public bool NewestOnTop
        {
            get => _newestOnTop;
            set
            {
                _newestOnTop = value;
                OnUpdate?.Invoke();
            }
        }

        public bool PreventDuplicates
        {
            get => _preventDuplicates;
            set
            {
                _preventDuplicates = value;
                OnUpdate?.Invoke();
            }
        }

        public int MaxDisplayedToasts
        {
            get => _maxDisplayedToasts;
            set
            {
                _maxDisplayedToasts = value;
                OnUpdate?.Invoke();
            }
        }

        public string PositionClass
        {
            get => _positionClass;
            set
            {
                _positionClass = value;
                OnUpdate?.Invoke();
            }
        }

        public string ToastClass { get; set; } = Defaults.Classes.Toast;
        public ToastIconClasses IconClasses = new ToastIconClasses();
        public bool ShowCloseIcon { get; set; } = true;
        public string CloseIconClass { get; set; } = Defaults.Classes.CloseIconClass;
        public decimal MaximumOpacity { get; set; } = 0.8m;
        public int VisibleStateDuration { get; set; } = 5000;
        public int VisibleStepDuration { get; set; } = 50;
        public int ShowTransitionDuration { get; set; } = 1000;
        public int ShowStepDuration { get; set; } = 100;
        public int HideTransitionDuration { get; set; } = 2000;
        public int HideStepDuration { get; set; } = 100;
        public bool ShowProgressBar { get; set; } = true;
        public string ProgressBarClass { get; set; } = Defaults.Classes.ProgressBarClass;

        public ToasterConfiguration()
        {
            PositionClass = Defaults.Classes.Position.TopRight;
            NewestOnTop = false;
            PreventDuplicates = true;
            MaxDisplayedToasts = 5;
        }

        internal string ToastTypeClass(ToastType type)
        {
            switch (type)
            {
                case ToastType.Info: return IconClasses.Info;
                case ToastType.Error: return IconClasses.Error;
                case ToastType.Success: return IconClasses.Success;
                case ToastType.Warning: return IconClasses.Warning;
                default: return IconClasses.Info;
            }
        }
    }
}
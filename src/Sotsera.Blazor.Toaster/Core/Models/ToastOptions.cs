using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToastOptions
    {
        public Action<Toast> Onclick { get; set; }
        public ToastType Type { get; }
        public string ToastClass { get; set; }
        public string ToastTypeClass { get; set; }
        public bool ShowCloseIcon { get; set; }
        public string CloseIconClass { get; set; }
        public decimal MaximumOpacity { get; set; }
        public int VisibleStateDuration { get; set; }
        public int VisibleStepDuration { get; set; }
        public int ShowTransitionDuration { get; set; }
        public int ShowStepDuration { get; set; }
        public int HideTransitionDuration { get; set; }
        public int HideStepDuration { get; set; }
        public bool ShowProgressBar { get; set; }
        public string ProgressBarClass { get; set; }

        public ToastOptions(ToastType type, ToasterConfiguration configuration)
        {
            Type = type;
            ToastClass = configuration.ToastClass;
            ToastTypeClass = configuration.ToastTypeClass(type);
            ShowCloseIcon = configuration.ShowCloseIcon;
            CloseIconClass = configuration.CloseIconClass;
            MaximumOpacity = configuration.MaximumOpacity;
            VisibleStateDuration = configuration.VisibleStateDuration;
            VisibleStepDuration = configuration.VisibleStepDuration;
            ShowTransitionDuration = configuration.ShowTransitionDuration;
            ShowStepDuration = configuration.ShowStepDuration;
            HideTransitionDuration = configuration.HideTransitionDuration;
            HideStepDuration = configuration.HideStepDuration;
            ShowProgressBar = configuration.ShowProgressBar;
            ProgressBarClass = configuration.ProgressBarClass;
        }
    }
}
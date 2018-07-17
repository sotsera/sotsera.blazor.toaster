using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToastOptions : CommonToastOptions
    {
        public Action<Toast> Onclick { get; set; }
        public ToastType Type { get; }
        public string ToastTypeClass { get; set; }

        public ToastOptions(ToastType type, ToasterConfiguration configuration)
        {
            Type = type;
            ToastTypeClass = configuration.ToastTypeClass(type);

            ToastClass = configuration.ToastClass;
            MaximumOpacity = configuration.MaximumOpacity;

            ShowTransitionDuration = configuration.ShowTransitionDuration;
            ShowStepDuration = configuration.ShowStepDuration;

            VisibleStateDuration = configuration.VisibleStateDuration;
            VisibleStepDuration = configuration.VisibleStepDuration;

            HideTransitionDuration = configuration.HideTransitionDuration;
            HideStepDuration = configuration.HideStepDuration;

            ShowProgressBar = configuration.ShowProgressBar;
            ProgressBarClass = configuration.ProgressBarClass;

            ShowCloseIcon = configuration.ShowCloseIcon;
            CloseIconClass = configuration.CloseIconClass;
        }
    }
}
using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToastOptions : ToasterConfiguration
    {
        public ToastType Type { get; }
        public Action<Toast> Onclick { get; set; }

        public ToastOptions(ToastType type, ToasterConfiguration configuration)
        {
            Type = type;
            ToastClass = configuration.ToastClass;
            IconClasses = configuration.IconClasses.Clone();
            PositionClass = configuration.PositionClass;
            ShowCloseIcon = configuration.ShowCloseIcon;
            CloseIconClass = configuration.CloseIconClass;
            ShowProgressBar = configuration.ShowProgressBar;
            ProgressBarClass = configuration.ProgressBarClass;

            MaximumOpacity = configuration.MaximumOpacity;

            VisibleStateDuration = configuration.VisibleStateDuration;
            VisibleStepDuration = configuration.VisibleStepDuration;
            ShowTransitionDuration = configuration.ShowTransitionDuration;
            ShowStepDuration = configuration.ShowStepDuration;
            HideTransitionDuration = configuration.HideTransitionDuration;
            HideStepDuration = configuration.HideStepDuration;
        }

        public string ToastTypeClass()
        {
            switch (Type)
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
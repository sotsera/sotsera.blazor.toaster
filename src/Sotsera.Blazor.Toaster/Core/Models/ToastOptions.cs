using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    /// <summary>
    /// Represents a toast specific options set
    /// </summary>
    public class ToastOptions : CommonToastOptions
    {
        /// <summary>
        /// The <see cref="Action"/> to be called on user click
        /// </summary>
        public Action<Toast> Onclick { get; set; }

        /// <summary>
        /// The <see cref="ToastType"/>
        /// </summary>
        public ToastType Type { get; }

        /// <summary>
        /// The css class representing it's state
        /// </summary>
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
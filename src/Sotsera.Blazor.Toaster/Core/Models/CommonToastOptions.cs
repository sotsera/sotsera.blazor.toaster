namespace Sotsera.Blazor.Toaster.Core.Models
{
    public abstract class CommonToastOptions
    {
        /// <summary>
        /// The main toast class. Defaults to <see cref="Defaults.Classes.Toast"/>
        /// </summary>
        public string ToastClass { get; set; } = Defaults.Classes.Toast;

        /// <summary>
        /// The maximum opacity expressed as an integer percentage for a toast in the <see cref="ToastState.Visible"/> state. Defaults to 80% where 0 means completely hidden and 100 means solid color.
        /// </summary>
        public int MaximumOpacity { get; set; } = 80;

        /// <summary>
        /// How long the showing transition takes to bring a toast to the <see cref="MaximumOpacity"/> and set it to the <see cref="ToastState.Visible"/> state. Defaults to 1000 ms.
        /// </summary>
        public int ShowTransitionDuration { get; set; } = 1000;

        /// <summary>
        /// Interval between component repaint during the showing trantition. Defaults to 100 ms.
        /// </summary>
        public int ShowStepDuration { get; set; } = 100;

        /// <summary>
        /// How long the toast remain visible without user interaction. Defaults to 5000 ms.
        /// </summary>
        public int VisibleStateDuration { get; set; } = 5000;

        /// <summary>
        /// Interval between component repaint during the Visible state: it's used only it the progressbar is shown. Defaults to 50 ms.
        /// </summary>
        public int VisibleStepDuration { get; set; } = 50;

        /// <summary>
        /// How long the hiding transition takes to make a toast disappear. Defaults to 2000 ms.
        /// </summary>
        public int HideTransitionDuration { get; set; } = 2000;

        /// <summary>
        /// Interval between component repaint during the hiding trantition. Defaults to 100 ms.
        /// </summary>
        public int HideStepDuration { get; set; } = 100;

        /// <summary>
        /// States if a progressbar has to be shown during the toast <see cref="ToastState.Visible"/> state. Defaults to true.
        /// </summary>
        public bool ShowProgressBar { get; set; } = true;

        /// <summary>
        /// The css class for the progress bar. Defaults to <see cref="Defaults.Classes.ProgressBarClass"/>.
        /// </summary>
        public string ProgressBarClass { get; set; } = Defaults.Classes.ProgressBarClass;

        /// <summary>
        /// States if the close icon has to be used for hiding a toast. The icon presence disables the default "hide on click" behaviour. Defaults to true.
        /// </summary>
        public bool ShowCloseIcon { get; set; } = true;

        /// <summary>
        /// The css class for the close icon. Defaults to <see cref="Defaults.Classes.CloseIconClass"/>.
        /// </summary>
        public string CloseIconClass { get; set; } = Defaults.Classes.CloseIconClass;
    }
}
namespace Sotsera.Blazor.Toaster.Core.Models
{
    public abstract class CommonToastOptions
    {
        public string ToastClass { get; set; } = Defaults.Classes.Toast;
        public decimal MaximumOpacity { get; set; } = 0.8m;

        public int ShowTransitionDuration { get; set; } = 1000;
        public int ShowStepDuration { get; set; } = 100;

        public int VisibleStateDuration { get; set; } = 5000;
        public int VisibleStepDuration { get; set; } = 50;

        public int HideTransitionDuration { get; set; } = 2000;
        public int HideStepDuration { get; set; } = 100;

        public bool ShowProgressBar { get; set; } = true;
        public string ProgressBarClass { get; set; } = Defaults.Classes.ProgressBarClass;

        public bool ShowCloseIcon { get; set; } = true;
        public string CloseIconClass { get; set; } = Defaults.Classes.CloseIconClass;
    }
}
namespace Sotsera.Blazor.Toaster.Core.Models
{
    public enum ToastState
    {
        Init,
        Showing,
        Hiding,
        Visible,
        ContinueTransition,
        MouseOver,
        Closing,
        Clicked
    }
}
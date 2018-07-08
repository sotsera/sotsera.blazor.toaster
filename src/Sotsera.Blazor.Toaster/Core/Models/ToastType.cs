namespace Sotsera.Blazor.Toaster.Core.Models
{
    public enum ToastType
    {
        Info,
        Success,
        Warning,
        Error
    }

    public static class ToastTypeExtensions
    {
        public static string Class(this ToastType position)
        {
            return $"toast-{position.ToString().ToLower()}";
        }
    }
}
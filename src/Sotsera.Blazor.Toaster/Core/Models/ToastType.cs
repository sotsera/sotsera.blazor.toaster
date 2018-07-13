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
        public static string Class(this ToastType type)
        {
            switch (type)
            {
                case ToastType.Info: return Defaults.Classes.Icons.Info;
                case ToastType.Error: return Defaults.Classes.Icons.Error;
                case ToastType.Success: return Defaults.Classes.Icons.Success;
                case ToastType.Warning: return Defaults.Classes.Icons.Warning;
                default: return Defaults.Classes.Icons.Info;
            }
        }
    }
}
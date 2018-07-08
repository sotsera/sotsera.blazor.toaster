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
                case ToastType.Info: return Constants.Classes.Icons.Info;
                case ToastType.Error: return Constants.Classes.Icons.Error;
                case ToastType.Success: return Constants.Classes.Icons.Success;
                case ToastType.Warning: return Constants.Classes.Icons.Warning;
                default: return Constants.Classes.Icons.Info;
            }
        }
    }
}
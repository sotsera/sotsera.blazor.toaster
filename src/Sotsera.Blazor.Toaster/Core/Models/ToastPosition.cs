namespace Sotsera.Blazor.Toaster.Core.Models
{
    public enum ToastPosition
    {
        TopRight
    }

    public static class ToastrPositionClassExtensions
    {
        public static string Class(this ToastPosition position)
        {
            switch (position)
            {
                case ToastPosition.TopRight:
                    return "toast-top-right";
                default:
                    return "toast-top-right";
            }
        }
    }
}
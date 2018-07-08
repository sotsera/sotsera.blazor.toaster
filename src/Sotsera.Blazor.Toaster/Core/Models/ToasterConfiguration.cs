using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core.Configuration
{
    public class ToasterConfiguration
    {
        public string ToastClass { get; set; } = "toast";
        public ToastPosition Position { get; set; } = ToastPosition.TopRight;
    }
}
using System;
using Sotsera.Blazor.Toaster.Core.Configuration;

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
            IconClass = configuration.IconClass;
            Position = configuration.Position;
        }
    }
}
using System;

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
            IconClasses = configuration.IconClasses.Clone();
            Position = configuration.Position;
        }

        public string ToastTypeClass()
        {
            switch (Type)
            {
                case ToastType.Info: return IconClasses.Info;
                case ToastType.Error: return IconClasses.Error;
                case ToastType.Success: return IconClasses.Success;
                case ToastType.Warning: return IconClasses.Warning;
                default: return IconClasses.Info;
            }
        }
    }
}
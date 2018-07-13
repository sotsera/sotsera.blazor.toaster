using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToastIconClasses
    {
        public string Info { get; set; } = Defaults.Classes.Icons.Info;
        public string Success { get; set; } = Defaults.Classes.Icons.Success;
        public string Warning { get; set; } = Defaults.Classes.Icons.Warning;
        public string Error { get; set; } = Defaults.Classes.Icons.Error;

        public ToastIconClasses Clone()
        {
            return new ToastIconClasses
            {
                Info = Info,
                Success = Success,
                Warning = Warning,
                Error = Error
            };
        }
    }
}
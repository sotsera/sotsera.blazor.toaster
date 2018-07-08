using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToastIconClasses
    {
        public string Info { get; set; } = Constants.Classes.Icons.Info;
        public string Success { get; set; } = Constants.Classes.Icons.Success;
        public string Warning { get; set; } = Constants.Classes.Icons.Warning;
        public string Error { get; set; } = Constants.Classes.Icons.Error;

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
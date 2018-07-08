namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class ToasterConfiguration
    {
        public string ToastClass { get; set; }
        public ToastIconClasses IconClasses;
        public string Position { get; set; }

        public ToasterConfiguration()
        {
            ToastClass = Constants.Classes.Toast;
            IconClasses = new ToastIconClasses();
            Position = Constants.Classes.Position.TopRight;
        }
    }
}
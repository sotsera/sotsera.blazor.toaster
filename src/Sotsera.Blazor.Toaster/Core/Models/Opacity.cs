using System.Globalization;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class Opacity
    {
        public decimal Max { get; }
        public decimal Value { get; private set; }

        public Opacity(decimal max)
        {
            if (max >= 100) Max = 1;
            else if (max <= 0) Max = 0;
            else Max = max / 100;
        }

        public void SetPercentage(decimal percentage)
        {
            if (percentage >= 100) Value = Max;
            else if (percentage <= 0) Value = 0;
            else Value = Max * percentage / 100;
        }

        public override string ToString()
        {
            return Value.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }
}

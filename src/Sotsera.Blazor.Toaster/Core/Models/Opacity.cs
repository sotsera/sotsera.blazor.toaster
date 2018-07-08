using System;
using System.Globalization;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class Opacity
    {
        public decimal Max { get; }
        public decimal Value { get; set; }

        public Opacity(decimal max)
        {
            Max = max;
        }

        public void SetPercentage(decimal percentage)
        {
            if (percentage >= 100) Value = Max;
            else if (percentage <= 0) Value = 0;
            else Value = Max * percentage / 100;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}

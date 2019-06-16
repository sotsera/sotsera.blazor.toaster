// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Sotsera.Blazor.Toaster.Core.Models
{
    public class Defaults
    {
        public class Classes
        {
            public const string Toast = "toast";
            public const string CloseIconClass = "toast-close-button";
            public const string ProgressBarClass = "toast-progress";

            public class Position
            {
                public const string TopCenter = "toast-top-center";
                public const string BottomCenter = "toast-bottom-center";
                public const string TopFullWidth = "toast-top-full-width";
                public const string BottomFullWidth = "toast-bottom-full-width";
                public const string TopLeft = "toast-top-left";
                public const string TopRight = "toast-top-right";
                public const string BottomRight = "toast-bottom-right";
                public const string BottomLeft = "toast-bottom-left";
            }

            public class Icons
            {
                public const string Info = "toast-info";
                public const string Success = "toast-success";
                public const string Warning = "toast-warning";
                public const string Error = "toast-error";
            }
        }
    }
}
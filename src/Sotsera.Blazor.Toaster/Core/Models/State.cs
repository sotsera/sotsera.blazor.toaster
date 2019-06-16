// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Sotsera.Blazor.Toaster.Core.Models
{
    internal class State
    {
        private string AnimationId { get; }
        public bool UserHasInteracted { get; set; }
        public ToastOptions Options { get; }
        public ToastState ToastState { get; set; }

        public State(ToastOptions options)
        {
            Options = options;
            AnimationId = $"toaster-{Guid.NewGuid()}";
            ToastState = ToastState.Init;
        }

        private string Opacity => ((decimal) Options.MaximumOpacity / 100).ToPercentage();
        public bool ShowCloseIcon => Options.ShowCloseIcon;
        public string ProgressBarClass => Options.ProgressBarClass;
        public string CloseIconClass => Options.CloseIconClass;
        
        public bool ShowProgressBar => Options.ShowProgressBar && ToastState.IsVisible() && !Options.RequireInteraction;

        public string ProgressBarStyle => $"width:100;animation:{AnimationId} {Options.VisibleStateDuration}ms;";

        public string AnimationStyle
        {
            get
            {
                const string template = "opacity: {0}; animation: {1}ms linear {2};";
                switch (ToastState)
                {
                    case ToastState.Showing:
                        return string.Format(template, Opacity, Options.ShowTransitionDuration, AnimationId);
                    case ToastState.Hiding:
                        return string.Format(template, 0, Options.HideTransitionDuration, AnimationId);
                    case ToastState.MouseOver:
                        return "opacity: 1;";
                    case ToastState.Visible:
                        return $"opacity: {Opacity};";
                    default:
                        return string.Empty;
                }
            }
        }

        public string ContainerClass
        {
            get
            {
                var forceCursor = Options.ShowCloseIcon ? "" : " force-cursor";
                return $"{Options.ToastClass} {Options.ToastTypeClass}{forceCursor}";
            }
        }

        public string TransitionClass
        {
            get
            {
                var template = "@keyframes " + AnimationId + " {{from{{ {0}: {1}; }} to{{ {0}: {2}; }}}}";

                switch (ToastState)
                {
                    case ToastState.Showing:
                        return string.Format(template, "opacity", 0, Opacity);
                    case ToastState.Hiding:
                        return string.Format(template, "opacity", Opacity, 0);
                    case ToastState.Visible:
                        return string.Format(template, "width", "100%", "0%");
                    default:
                        return string.Empty;
                }
            }
        }
    }
}

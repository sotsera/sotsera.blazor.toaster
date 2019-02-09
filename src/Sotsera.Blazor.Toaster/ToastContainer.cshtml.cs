using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster
{
    public class ToastContainerModel : ComponentBase, IDisposable
    {
        [Inject]
        private IToaster Toaster { get; set; }

        public IEnumerable<Toast> Toasts
        {
            get
            {
                var toasts = Toaster.Toasts.Take(Toaster.Configuration.MaxDisplayedToasts);

                return Toaster.Configuration.NewestOnTop
                    ? toasts.Reverse()
                    : toasts;
            }
        }

        public string Class => Toaster.Configuration.PositionClass;

        protected override void OnInit()
        {
            base.OnInit();
            Toaster.OnToastsUpdated += StateHasChanged;
        }

        public void Dispose()
        {
            Toaster.OnToastsUpdated -= StateHasChanged;
        }
    }
}
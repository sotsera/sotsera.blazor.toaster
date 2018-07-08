using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Blazor.Components;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster
{
    public class ToastContainerModel : BlazorComponent, IDisposable
    {
        [Inject]
        private IToaster Toaster { get; set; }

        public IEnumerable<Toast> Toasts
        {
            get
            {
                var newestOnTop = Toaster.Configuration.NewestOnTop;
                var numberOfToasts = Toaster.Configuration.MaxDisplayedToasts;

                return newestOnTop
                    ? Toaster.Toasts.Reverse().Take(numberOfToasts)
                    : Toaster.Toasts.Take(numberOfToasts);
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
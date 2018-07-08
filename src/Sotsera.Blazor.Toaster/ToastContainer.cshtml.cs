using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Blazor.Components;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster
{
    public class ToastContainerModel : BlazorComponent, IDisposable
    {
        [Inject]
        private IToaster Toastr { get; set; }

        public IList<Toast> Toasts => Toastr.Toasts;
        public string Class => Toastr.Configuration.Position.Class();

        protected override void OnInit()
        {
            base.OnInit();
            Toastr.OnToastsUpdated += StateHasChanged;
        }

        public void Dispose()
        {
            Toastr.OnToastsUpdated -= StateHasChanged;
        }
    }
}
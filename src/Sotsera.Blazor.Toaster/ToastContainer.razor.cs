// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Sotsera.Blazor.Toaster.Core;

namespace Sotsera.Blazor.Toaster
{
    public class ToastContainerModel : ComponentBase, IDisposable
    {
        [Inject] private IToaster Toaster { get; set; }

        protected IEnumerable<Toast> Toasts => Toaster.Configuration.NewestOnTop
                ? Toaster.ShownToasts.Reverse()
                : Toaster.ShownToasts;

        protected string Class => Toaster.Configuration.PositionClass;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Toaster.OnToastsUpdated += () => InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            Toaster.OnToastsUpdated -= StateHasChanged;
        }
    }
}
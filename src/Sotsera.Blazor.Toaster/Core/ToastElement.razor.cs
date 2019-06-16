// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Components;

namespace Sotsera.Blazor.Toaster.Core
{
    public class ToastElementModel : ComponentBase, IDisposable
    {
        [Parameter]
        protected Toast Toast { get; set; }
        protected RenderFragment Css;

        protected string Title => Toast.Title;
        protected string Message => Toast.Message;

        protected void Clicked(UIEventArgs args) => Toast.Clicked(false);
        protected void CloseIconClicked(UIEventArgs args) => Toast.Clicked(true);
        protected void MouseEnter(UIEventArgs args) => Toast.MouseEnter();
        protected void MouseLeave(UIEventArgs args) => Toast.MouseLeave();

        protected override void OnInit()
        {
            Toast.OnUpdate += ToastUpdated;
            Toast.Init();

            Css = builder =>
            {
                var transitionClass = Toast.State.TransitionClass;
                if (transitionClass.IsEmpty()) return;

                builder.OpenElement(1, "style");
                builder.AddContent(2, transitionClass);
                builder.CloseElement();
            };
        }

        private void ToastUpdated()
        {
            Invoke(StateHasChanged);
        }

        public void Dispose()
        {
            if (Toast != null)
            {
                Toast.OnUpdate -= ToastUpdated;
            }
        }
    }
}
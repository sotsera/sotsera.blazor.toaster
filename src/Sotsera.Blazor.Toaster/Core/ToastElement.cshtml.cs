using System;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core
{
    public class ToastElementModel : BlazorComponent, IDisposable
    {
        [Parameter]
        private Toast Toast { get; set; }
        public string ContainerClass => Toast.ContainerClass;
        public string ContainerStyle => Toast.ContainerStyle;
        public bool ShowCloseIcon => Toast.Options.ShowCloseIcon;
        public string CloseIconClass => Toast.Options.CloseIconClass;
        public bool ShowProgressBar => Toast.Options.ShowProgressBar && Toast.State == ToastState.Visible;
        public string ProgressBarClass => Toast.Options.ProgressBarClass;
        public string ProgressBarStyle => Toast.ProgressBarStyle;
        public string Title => Toast.Title;
        public string Message => Toast.Message;

        public void Clicked(UIEventArgs args) => Toast.Clicked(false);
        public void CloseIconClicked(UIEventArgs args) => Toast.Clicked(true);
        public void MouseEnter(UIEventArgs args) => Toast.MouseEnter();
        public void MouseLeave(UIEventArgs args) => Toast.MouseLeave();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Toast.OnUpdate += ToastUpdated;
            Toast.EnsureInitialized();
        }

        private void ToastUpdated() => StateHasChanged();

        public void Dispose()
        {
            if (Toast != null)
            {
                Toast.OnUpdate -= ToastUpdated;
            }
        }
    }
}
using System;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace Sotsera.Blazor.Toaster.Core
{
    public class ToastElementModel : BlazorComponent, IDisposable
    {
        [Parameter]
        private Toast Toast { get; set; }
        public string ContainerClass => Toast.ContainerClass;
        public string ContainerStyle => Toast.ContainerStyle;
        public string Title => Toast.Title;
        public string Message => Toast.Message;

        public void Clicked(UIEventArgs args) => Toast.Clicked();
        public void MouseEnter(UIEventArgs args) => Toast.MouseEnter();
        public void MouseLeave(UIEventArgs args) => Toast.MouseLeave();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Toast.OnUpdate += ToastUpdated;
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
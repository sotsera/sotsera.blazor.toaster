using System;
using System.Collections.Generic;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster
{
    public interface IToaster : IDisposable
    {
        IList<Toast> Toasts { get; }
        ToasterConfiguration Configuration { get; }

        event Action OnToastsUpdated;

        void Error(string message, string title = null, Action<ToastOptions> configure = null);
        void Info(string message, string title = null, Action<ToastOptions> configure = null);
        void Success(string message, string title = null, Action<ToastOptions> configure = null);
        void Warning(string message, string title = null, Action<ToastOptions> configure = null);
        void Add(ToastType type, string message, string title, Action<ToastOptions> configure);

        void Clear();
        void Remove(Toast toast);
    }
}
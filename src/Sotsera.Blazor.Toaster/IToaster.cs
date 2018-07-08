using System;
using System.Collections.Generic;
using Sotsera.Blazor.Toaster.Configuration;

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

        void Clear();
        void Remove(Toast toast);
    }
}
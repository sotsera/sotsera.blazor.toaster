// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster.Core
{
    /// <inheritdoc />
    public class Toaster : IToaster
    {
        public ToasterConfiguration Configuration { get; }
        public event Action OnToastsUpdated;
        public IList<Toast> Toasts { get; private set; } = new List<Toast>();
        public string Version { get; }

        public Toaster(ToasterConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.OnUpdate += ConfigurationUpdated;
            Version = GetType().InformationalVersion();
        }

        public void Info(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Info, message, title, configure);
        }

        public void Info(IList<string> messages, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Info, messages, title, configure);
        }

        public void Success(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Success, message, title, configure);
        }

        public void Success(IList<string> messages, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Success, messages, title, configure);
        }

        public void Warning(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Warning, message, title, configure);
        }

        public void Warning(IList<string> messages, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Warning, messages, title, configure);
        }

        public void Error(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Error, message, title, configure);
        }

        public void Error(IList<string> messages, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Error, messages, title, configure);
        }

        public void Add(ToastType type, string message, string title, Action<ToastOptions> configure)
        {
            Add(type, new List<string> {message}, title, configure);
        }

        public void Add(ToastType type, IList<string> messages, string title, Action<ToastOptions> configure)
        {
            var toastMessages = messages.NotEmptyValues();
            if (toastMessages.Count == 0) return;

            title = title.Trimmed();

            if (Configuration.PreventDuplicates && ToastAlreadyPresent(toastMessages, title, type)) return;

            var options = new ToastOptions(type, Configuration);
            configure?.Invoke(options);

            var toast = new Toast(title, toastMessages, options);
            toast.OnClose += Remove;
            Toasts.Add(toast);

            OnToastsUpdated?.Invoke();
        }

        public void Clear()
        {
            var toasts = Toasts;
            Toasts = new List<Toast>();
            OnToastsUpdated?.Invoke();
            DisposeToasts(toasts);
        }

        public void Remove(Toast toast)
        {
            toast.OnClose -= Remove;
            Toasts.Remove(toast);
            
            OnToastsUpdated?.Invoke();
            toast.Dispose();
        }

        private bool ToastAlreadyPresent(IList<string> messages, string title, ToastType type)
        {
            return Toasts.Any(toast =>
                messages.SequenceEqual(toast.Messages) &&
                title.Equals(toast.Title) &&
                type.Equals(toast.State.Options.Type)
            );
        }

        private void ConfigurationUpdated()
        {
            OnToastsUpdated?.Invoke();
        }

        public void Dispose()
        {
            Configuration.OnUpdate -= ConfigurationUpdated;
            DisposeToasts(Toasts);
        }

        private void DisposeToasts(IEnumerable<Toast> toasts)
        {
            foreach (var toast in toasts)
            {
                toast.OnClose -= Remove;
                toast.Dispose();
            }
        }
    }
}
// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// This is an adaptation of https://github.com/aspnet/AspNetCore/blob/87ea03daf12df8f6f5e606a001af607f12e2da09/src/Components/Components/src/Forms/ValidationSummary.cs
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Sotsera.Blazor.Toaster
{
    /// <summary>
    /// Displays the validation messages from a cascaded <see cref="EditContext"/> in a <see cref="Core.ToastElement"/>.
    /// </summary>
    public class ToasterValidationSummary : ComponentBase, IDisposable
    {
        private EditContext _previousEditContext;
        private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
        
        /// <summary>
        /// The form reference to be used as <see cref="Core.ToastElement"/> title.
        /// </summary>
        [Parameter] public string FormName { get; private set; }

        /// <summary>
        /// Sets the error messages display mode.
        /// </summary>
        [Parameter] public DisplayMode DisplayMode { get; private set; }

        [Inject] IToaster Toaster { get; set; }
        [CascadingParameter] EditContext CurrentEditContext { get; set; }

        /// <summary>`
        /// Constructs an instance of <see cref="ToasterValidationSummary"/>.
        /// </summary>
        public ToasterValidationSummary() 
        {
            _validationStateChangedHandler = (sender, eventArgs) =>
            {
                if (DisplayMode == DisplayMode.Aggregate)
                {
                    Toaster.Error(CurrentEditContext.GetValidationMessages().ToList(), FormName);
                    return;
                }

                foreach (var message in CurrentEditContext.GetValidationMessages())
                {
                    Toaster.Error(message, FormName);
                }
            };
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(ToasterValidationSummary)} requires a cascading parameter " +
                    $"of type {nameof(EditContext)}. For example, you can use {nameof(ToasterValidationSummary)} inside " +
                    $"an {nameof(EditForm)}.");
            }

            if (CurrentEditContext != _previousEditContext)
            {
                DetachValidationStateChangedListener();
                CurrentEditContext.OnValidationStateChanged += _validationStateChangedHandler;
                _previousEditContext = CurrentEditContext;
            }
        }

        void IDisposable.Dispose()
        {
            DetachValidationStateChangedListener();
        }

        private void DetachValidationStateChangedListener()
        {
            if (_previousEditContext != null)
            {
                _previousEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
            }
        }
    }

    /// <summary>
    /// The error messages display mode
    /// </summary>
    public enum DisplayMode
    {
        /// <summary>
        /// Use a single toast with a list of messages
        /// </summary>
        Aggregate,
        /// <summary>
        /// One toast for every message
        /// </summary>
        Individual
    }
}
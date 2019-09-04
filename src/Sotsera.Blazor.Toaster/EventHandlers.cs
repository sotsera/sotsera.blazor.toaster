// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Sotsera.Blazor.Toaster
{
    /// <summary>
    /// Needed because of https://github.com/aspnet/AspNetCore/issues/13104
    /// </summary>
    [EventHandler("onmouseenter", typeof(MouseEventArgs))]
    [EventHandler("onmouseleave", typeof(MouseEventArgs))]
    public static class EventHandlers
    {
    }
}
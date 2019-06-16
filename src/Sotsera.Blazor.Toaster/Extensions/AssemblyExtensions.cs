// Copyright (c) Alessandro Ghidini. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Sotsera.Blazor.Toaster
{
    internal static class AssemblyExtensions
    {
        public static string InformationalVersion(this Type type)
        {
            return type.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}

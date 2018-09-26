using System;
using System.Reflection;

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

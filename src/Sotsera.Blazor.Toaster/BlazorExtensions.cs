using System;
using Sotsera.Blazor.Toaster;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class BlazorExtensions
    {
        public static IServiceCollection AddToaster(this IServiceCollection services, ToasterConfiguration configuration)
        {
            if(configuration == null) throw new ArgumentNullException(nameof(configuration));
            return services.AddSingleton<IToaster>(new Toaster(configuration));
        }

        public static IServiceCollection AddToaster(this IServiceCollection services)
        {
            return AddToaster(services, new ToasterConfiguration());
        }

        public static IServiceCollection AddToaster(this IServiceCollection services, Action<ToasterConfiguration> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var options = new ToasterConfiguration();
            configure(options);

            return AddToaster(services, options);
        }
    }
}
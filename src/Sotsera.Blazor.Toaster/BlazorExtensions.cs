using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sotsera.Blazor.Toaster;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Models;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides the <see cref="Toaster"/> configuration entry points
    /// </summary>
    public static class BlazorExtensions
    {
        /// <summary>
        /// Adds a singleton <see cref="IToaster"/> instance to the DI <see cref="IServiceCollection"/> with the specified <see cref="ToasterConfiguration"/>
        /// </summary>
        public static IServiceCollection AddToaster(this IServiceCollection services, ToasterConfiguration configuration)
        {
            if(configuration == null) throw new ArgumentNullException(nameof(configuration));
            services.TryAddScoped<IToaster>(builder => new Toaster(configuration));
            return services;
        }

        /// <summary>
        /// Adds a singleton <see cref="IToaster"/> instance to the DI <see cref="IServiceCollection"/> with the default <see cref="ToasterConfiguration"/>
        /// </summary>
        public static IServiceCollection AddToaster(this IServiceCollection services)
        {
            return AddToaster(services, new ToasterConfiguration());
        }

        /// <summary>
        /// Adds a singleton <see cref="IToaster"/> instance to the DI <see cref="IServiceCollection"/> with an action for configuring the default <see cref="ToasterConfiguration"/>
        /// </summary>
        public static IServiceCollection AddToaster(this IServiceCollection services, Action<ToasterConfiguration> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var options = new ToasterConfiguration();
            configure(options);

            return AddToaster(services, options);
        }
    }
}
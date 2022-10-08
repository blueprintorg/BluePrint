using Microsoft.Extensions.DependencyInjection;
using System;

namespace BluePrint.DependencyInjection.Container.Providers
{
    public static class ServiceLocator
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>
        /// The service provider.
        /// </value>
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Creates the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}

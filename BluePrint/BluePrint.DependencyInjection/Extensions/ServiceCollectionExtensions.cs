using BluePrint.DependencyInjection.Container.Providers;
using BluePrint.DependencyInjection.Modules.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace BluePrint.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the dependency resolvers.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="modules">The modules.</param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            IBluePrintModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceLocator.Create(services);
        }
    }
}


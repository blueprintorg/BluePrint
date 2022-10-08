using BluePrint.CrossCuttingConcern.Caching.Manager.Behaviors;
using BluePrint.CrossCuttingConcern.Caching.Manager.Concretes;
using BluePrint.DependencyInjection.Modules.Behaviors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace BluePrint.DependencyInjection.Modules.Concretes
{
    public class BluePrintModule : IBluePrintModule
    {
        /// <summary>
        /// Loads the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void Load(IServiceCollection collection)
        {
            collection.AddMemoryCache();
            collection.AddSingleton<ICacheManager, MemoryCacheManager>();
            collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            collection.AddSingleton<Stopwatch>();
        }
    }
}

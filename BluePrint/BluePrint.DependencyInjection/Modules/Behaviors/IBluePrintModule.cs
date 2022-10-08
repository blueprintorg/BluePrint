using Microsoft.Extensions.DependencyInjection;

namespace BluePrint.DependencyInjection.Modules.Behaviors
{
    public interface IBluePrintModule
    {
        /// <summary>
        /// Loads the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        void Load(IServiceCollection collection);
    }
}

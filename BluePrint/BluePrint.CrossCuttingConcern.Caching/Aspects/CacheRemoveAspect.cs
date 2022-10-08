using BluePrint.CrossCuttingConcern.Caching.Manager.Behaviors;
using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using BluePrint.DependencyInjection.Container.Providers;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace BluePrint.CrossCuttingConcern.Caching.Aspects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BluePrint.CrossCuttingConcern.Utilities.Interceptors.MethodInterception" />
    public class CacheRemoveAspect : MethodInterception
    {
        /// <summary>
        /// The pattern
        /// </summary>
        private readonly string pattern;

        /// <summary>
        /// The cache extension
        /// </summary>
        private readonly ICacheManager cacheExtension;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheRemoveAspect"/> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public CacheRemoveAspect(string pattern)
        {
            this.pattern = pattern;
            this.cacheExtension = ServiceLocator.ServiceProvider.GetService<ICacheManager>();
        }

        /// <summary>
        /// Called when [success].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        protected override void OnSuccess(IInvocation invocation)
        {
            this.cacheExtension.RemoveByPattern(this.pattern);
        }
    }
}

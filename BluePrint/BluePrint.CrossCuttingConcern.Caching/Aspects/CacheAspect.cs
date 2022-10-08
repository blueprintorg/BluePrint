using BluePrint.CrossCuttingConcern.Caching.Manager.Behaviors;
using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using BluePrint.DependencyInjection.Container.Providers;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BluePrint.CrossCuttingConcern.Caching.Aspects
{
    public class CacheAspect : MethodInterception
    {
        private readonly int duration;

        private readonly ICacheManager cacheExtension;

        public CacheAspect(int duration = 60)
        {
            this.duration = duration;
            this.cacheExtension = ServiceLocator.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (this.cacheExtension.IsAdd(key))
            {
                invocation.ReturnValue = this.cacheExtension.Get(key);
                return;
            }
            invocation.Proceed();
            this.cacheExtension.Add(key, invocation.ReturnValue, this.duration);
        }
    }
}

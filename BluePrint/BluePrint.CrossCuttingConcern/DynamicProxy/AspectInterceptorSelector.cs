namespace BluePrint.CrossCuttingConcern.DynamicProxy
{
    using BluePrint.CrossCuttingConcern.ExceptionHandling.Aspects;
    using BluePrint.CrossCuttingConcern.Logging.Helpers;
    using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
    using Castle.DynamicProxy;
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Castle.DynamicProxy.IInterceptorSelector" />
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        /// <summary>
        /// Selects the interceptors that should intercept calls to the given <paramref name="method" />.
        /// </summary>
        /// <param name="type">The type of the target object.</param>
        /// <param name="method">The method that will be intercepted.</param>
        /// <param name="interceptors">All interceptors registered with the proxy.</param>
        /// <returns>
        /// An array of interceptors to invoke upon calling the <paramref name="method" />.
        /// </returns>
        /// <remarks>
        /// This method is called only once per proxy instance, upon the first call to the
        /// <paramref name="method" />. Either an empty array or null are valid return values to indicate
        /// that no interceptor should intercept calls to the method. Although it is not advised, it is
        /// legal to return other <see cref="T:Castle.DynamicProxy.IInterceptor" /> implementations than these provided in
        /// <paramref name="interceptors" />.
        /// </remarks>
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionHandlingAspect(typeof(FileLogger)));


            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}

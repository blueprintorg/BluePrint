using BluePrint.CrossCuttingConcern.Utilities.Interceptors;
using BluePrint.DependencyInjection.Container.Providers;
using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace BluePrint.CrossCuttingConcern.Scheduling.Aspects
{
    public class SchedulingAspect : MethodInterception
    {
        private readonly int interval;
        private readonly Stopwatch stopwatch;

        public SchedulingAspect(int interval)
        {
            this.interval = interval;
            this.stopwatch = ServiceLocator.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            this.stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (this.stopwatch.Elapsed.TotalSeconds > this.interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{this.stopwatch.Elapsed.TotalSeconds}");
            }
            this.stopwatch.Reset();
        }
    }
}

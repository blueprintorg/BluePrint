using Autofac;
using Autofac.Extras.DynamicProxy;
using BluePrint.CrossCuttingConcern.DynamicProxy;
using Castle.DynamicProxy;

namespace BluePrint.Business.Unit.Foundations.Ioc
{
    public class DynamicProxyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

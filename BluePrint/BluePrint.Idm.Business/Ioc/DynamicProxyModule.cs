namespace BluePrint.Idm.Business.Ioc
{
    using Autofac;
    using Autofac.Extras.DynamicProxy;
    using BluePrint.CrossCuttingConcern.DynamicProxy;
    using Castle.DynamicProxy;

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

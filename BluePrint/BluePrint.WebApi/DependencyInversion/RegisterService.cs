using BluePrint.Business.Unit.Foundations.Behaviors;
using BluePrint.Business.Unit.Foundations.Concretes;
using BluePrint.DataAccess.Infrastructure.UnitOfWork.Behaviors;
using BluePrint.DataAccess.Infrastructure.UnitOfWork.Concretes;
using BluePrint.DataAccess.Persistance.Context;
using BluePrint.DataAccess.Unit.Foundations.Behaviors;
using BluePrint.DataAccess.Unit.Foundations.Concretes;
using BluePrint.DependencyInjection.Modules.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace BluePrint.WebApi.DependencyInversion
{
    public class RegisterService : IBluePrintModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddScoped<IDemoBusiness,DemoBusiness>();

            collection.AddScoped<IDemoRepository, DemoRepository>();

            collection.AddScoped<IUnitOfWork<BluePrintContext>, UnitOfWork<BluePrintContext>>();

        }
    }
}

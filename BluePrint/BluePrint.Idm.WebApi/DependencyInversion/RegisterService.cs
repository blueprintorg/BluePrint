using BluePrint.DataAccess.Infrastructure.UnitOfWork.Behaviors;
using BluePrint.DataAccess.Infrastructure.UnitOfWork.Concretes;
using BluePrint.DependencyInjection.Modules.Behaviors;
using BluePrint.Idm.Business.Behaviors;
using BluePrint.Idm.Business.Concretes;
using BluePrint.Idm.DataAccess.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace BluePrint.Idm.WebApi.DependencyInversion
{
    public class RegisterService : IBluePrintModule
    {
        public void Load(IServiceCollection collection)
        {
            collection.AddScoped<IUnitOfWork<IdmContext>, UnitOfWork<IdmContext>>();

            collection.AddScoped<IUserBusiness, UserBusiness>();
            collection.AddScoped<IRoleBusiness, RoleBusiness>();
        }
    }
}

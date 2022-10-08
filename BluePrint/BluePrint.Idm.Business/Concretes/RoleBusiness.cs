using Autofac;
using BluePrint.Business.Abstracts;
using BluePrint.Common.Rest;
using BluePrint.Idm.Business.Behaviors;
using BluePrint.Idm.DataAccess.Persistence.Context;
using BluePrint.Idm.Model.Dtos;
using BluePrint.Idm.Model.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BluePrint.Idm.Business.Concretes
{
    public class RoleBusiness : BaseBusiness<RoleDto, RoleEntity, IdmContext>, IRoleBusiness
    {
        public RoleBusiness(IComponentContext componentContext) : base(componentContext)
        {
        }

        public async Task<ServiceResult<RoleDto>> CreateAsync(RoleDto role)
        {
            var roleEntity = this.Mapper.Map<RoleDto, RoleEntity>(role);
            var roleManager = base.ComponentContext.Resolve<RoleManager<RoleEntity>>();
            var response = await roleManager.CreateAsync(roleEntity);

            if (response.Succeeded)
            {
                return new ServiceResult<RoleDto>(role, response.ToString());
            }
            else
            {
                return new ServiceResult<RoleDto>(response.ToString());
            }
        }
    }
}

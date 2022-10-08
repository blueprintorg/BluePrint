using Autofac;
using BluePrint.Business.Abstracts;
using BluePrint.Common.Rest;
using BluePrint.Idm.Business.Behaviors;
using BluePrint.Idm.DataAccess.Persistence.Context;
using BluePrint.Idm.Model.Dtos;
using BluePrint.Idm.Model.Entities;
using BluePrint.Idm.Model.Resources;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BluePrint.Idm.Business.Concretes
{
    public class UserBusiness : BaseBusiness<UserDto, UserEntity, IdmContext>, IUserBusiness
    {
        public UserBusiness(IComponentContext componentContext) : base(componentContext)
        {
        }

        public async Task<ServiceResult<RoleAssignResource>> AddToRoleAsync(RoleAssignResource roleAssignResource)
        {
            var userManager = base.ComponentContext.Resolve<UserManager<UserEntity>>();
            var user = await userManager.FindByIdAsync(roleAssignResource.UserId.ToString());

            var roleManager = base.ComponentContext.Resolve<RoleManager<RoleEntity>>();
            var role = await roleManager.FindByIdAsync(roleAssignResource.RoleId.ToString());
            var response = await userManager.AddToRoleAsync(user, role.Name);

            if (response.Succeeded)
            {
                roleAssignResource.HasAssign = true;
                return new ServiceResult<RoleAssignResource>(roleAssignResource, response.ToString());
            }
            else
            {
                return new ServiceResult<RoleAssignResource>(response.ToString());
            }
        }

        public async Task<ServiceResult<UserDto>> CreateAsync(UserDto user)
        {
            var userEntity = this.Mapper.Map<UserDto, UserEntity>(user);
            var userManager = base.ComponentContext.Resolve<UserManager<UserEntity>>();
            var response = await userManager.CreateAsync(userEntity);

            if (response.Succeeded)
            {
                return new ServiceResult<UserDto>(user, response.ToString());
            }
            else
            {
                return new ServiceResult<UserDto>(response.ToString());
            }
        }
    }
}

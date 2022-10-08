using BluePrint.Common.Rest;
using BluePrint.Idm.Model.Dtos;
using BluePrint.Idm.Model.Resources;
using System.Threading.Tasks;

namespace BluePrint.Idm.Business.Behaviors
{
    public interface IUserBusiness
    {
        Task<ServiceResult<UserDto>> CreateAsync(UserDto user);

        Task<ServiceResult<RoleAssignResource>> AddToRoleAsync(RoleAssignResource roleAssignResource);

    }
}

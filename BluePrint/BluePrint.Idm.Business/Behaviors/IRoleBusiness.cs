using BluePrint.Common.Rest;
using BluePrint.Idm.Model.Dtos;
using System.Threading.Tasks;

namespace BluePrint.Idm.Business.Behaviors
{
    public interface IRoleBusiness
    {
        Task<ServiceResult<RoleDto>> CreateAsync(RoleDto role);

    }
}

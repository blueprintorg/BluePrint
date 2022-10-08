using Autofac;
using BluePrint.Common.Rest;
using BluePrint.Idm.Business.Behaviors;
using BluePrint.Idm.Model.Dtos;
using BluePrint.Idm.Model.Resources;
using BluePrint.Presentation.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BluePrint.Idm.WebApi.Controllers
{
    [Route("api/idm/user")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IComponentContext componentContext) : base(componentContext)
        {
        }

        [HttpPost]
        [Route("CreateAsync")]
        public async Task<ServiceResult<UserDto>> CreateAsync(UserDto user)
        {
            var ioc = base.ComponentContext.Resolve<IUserBusiness>();
            return await ioc.CreateAsync(user);
        }

        [HttpPost]
        [Route("AddToRoleAsync")]
        public async Task<ServiceResult<RoleAssignResource>> AddToRoleAsync(RoleAssignResource resource)
        {
            var ioc = base.ComponentContext.Resolve<IUserBusiness>();
            return await ioc.AddToRoleAsync(resource);
        }

    }
}

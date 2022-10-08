using Autofac;
using BluePrint.Common.Rest;
using BluePrint.Idm.Business.Behaviors;
using BluePrint.Idm.Model.Dtos;
using BluePrint.Presentation.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BluePrint.Idm.WebApi.Controllers
{
    [Route("api/idm/role")]
    [ApiController]
    public class RoleController : BaseController
    {
        public RoleController(IComponentContext componentContext) : base(componentContext)
        {
        }

        [HttpPost]
        [Route("CreateAsync")]
        public async Task<ServiceResult<RoleDto>> CreateAsync(RoleDto role)
        {
            var ioc = base.ComponentContext.Resolve<IRoleBusiness>();
            return await ioc.CreateAsync(role);
        }
    }
}

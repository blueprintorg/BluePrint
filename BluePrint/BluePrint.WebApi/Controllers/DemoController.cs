using Autofac;
using BluePrint.Business.Unit.Foundations.Behaviors;
using BluePrint.Common.Rest;
using BluePrint.Model.Dtos.Behaviors;
using BluePrint.Model.Unit.Foundations.Dtos;
using BluePrint.Presentation.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BluePrint.WebApi.Controllers
{
    [Route("api/demo")]
    [ApiController]
    public class DemoController : BaseController
    {
        public DemoController(IComponentContext componentContext) : base(componentContext)
        {
        }

        [HttpGet]
        [Route("getAll")]
        public ServiceResult<IPagingDto<DemoDto>> Get()
        {
            var ioc = base.ComponentContext.Resolve<IDemoBusiness>();
            return ioc.GetAllDemoService();
        }

        [HttpPost]
        [Route("addRange")]
        public ServiceResult<bool> AddRange()
        {
            var ioc = base.ComponentContext.Resolve<IDemoBusiness>();
            return ioc.AddRangeDemoService();
        }

        [HttpPost]
        [Route("post")]
        public ServiceResult<DemoDto> Post(DemoDto demoDto)
        {
            var ioc = base.ComponentContext.Resolve<IDemoBusiness>();
            return ioc.CreateDemoService(demoDto);
        }

        [HttpPut]
        [Route("put")]
        public ServiceResult<DemoDto> Put(DemoDto demoDto)
        {
            var ioc = base.ComponentContext.Resolve<IDemoBusiness>();
            return ioc.UpdateDemoService(demoDto);
        }

        [HttpPost]
        [Route("transaction")]
        public ServiceResult<bool> TransactionalOperation(DemoDto demoDto)
        {
            var ioc = base.ComponentContext.Resolve<IDemoBusiness>();
            return ioc.TransactionalOperation(demoDto);
        }
    }
}
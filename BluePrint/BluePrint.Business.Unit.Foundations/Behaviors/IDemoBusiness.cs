using BluePrint.Common.Rest;
using BluePrint.Model.Dtos.Behaviors;
using BluePrint.Model.Unit.Foundations.Dtos;

namespace BluePrint.Business.Unit.Foundations.Behaviors
{
    public interface IDemoBusiness
    {
        ServiceResult<DemoDto> CreateDemoService(DemoDto dto);

        ServiceResult<DemoDto> UpdateDemoService(DemoDto dto);

        ServiceResult<bool> AddRangeDemoService();

        ServiceResult<bool> TransactionalOperation(DemoDto dto);

        ServiceResult<IPagingDto<DemoDto>> GetAllDemoService();
    }
}

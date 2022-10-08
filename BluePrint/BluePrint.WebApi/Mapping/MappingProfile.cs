using AutoMapper;
using BluePrint.Model.Dtos.Behaviors;
using BluePrint.Model.Entities.Behaviors;
using BluePrint.Model.Unit.Foundations.Dtos;
using BluePrint.Model.Unit.Foundations.Entities;

namespace BluePrint.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DemoEntity, DemoDto>().ReverseMap();
            CreateMap<IPagingEntity<DemoEntity>, IPagingDto<DemoDto>>().ReverseMap();
        }
    }
}

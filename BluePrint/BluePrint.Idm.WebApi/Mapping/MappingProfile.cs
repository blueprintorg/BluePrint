using AutoMapper;
using BluePrint.Idm.Model.Dtos;
using BluePrint.Idm.Model.Entities;

namespace BluePrint.Idm.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<RoleEntity, RoleDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using ilearn_users_api.Controllers.Responses;
using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;

namespace ilearn_users_api.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
        }
    }
}

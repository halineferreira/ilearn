using AutoMapper;
using ilearn_users_api.Controllers.Responses;
using ilearn_users_api.Domain.Entities;
using ilearn_users_api.Domain.ValueObjects;
using ilearn_users_api.Data.Schemas;

namespace ilearn_users_api.Mappings
{
    public class SchemaToModelMappingProfile : Profile
    {
        public SchemaToModelMappingProfile()
        {
            CreateMap<UserSchema, User>().ReverseMap();
            CreateMap<AddressSchema, Address>().ReverseMap();
            CreateMap<SubjectSchema, Subject>().ReverseMap();
        }
    }
}

using AutoMapper;
using Dealership.DomainEntities;
using Dealership.WebAPI.Dtos;

namespace Dealership.WebAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Model, ModelDto>();
            Mapper.CreateMap<ModelDto, Model>();
        }
    }
}
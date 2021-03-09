using AutoMapper;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Mappings.Profiles
{

    public class ObjectiveMappingProfile : Profile
    {
        public ObjectiveMappingProfile()
        {
            CreateMap<ObjectiveModel, Objectives>()
                .ReverseMap();

            CreateMap<ObjectiveProgressModel, ObjectiveModel>()
                .ReverseMap();
        }
    }
}

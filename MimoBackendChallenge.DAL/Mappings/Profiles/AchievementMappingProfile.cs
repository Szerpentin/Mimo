using AutoMapper;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Mappings.Profiles
{
    public class AchievementMappingProfile : Profile
    {
        public AchievementMappingProfile()
        {
            CreateMap<AchievementModel, Achievements>()
                .ForMember(dest => dest.Objective, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ReverseMap(); ;
        }
    }
}

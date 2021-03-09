using AutoMapper;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Mappings.Profiles
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<LessonModel, Lessons>().ForMember(dest => dest.Chapter, opt => opt.Ignore()).ReverseMap();
        }
    }
}

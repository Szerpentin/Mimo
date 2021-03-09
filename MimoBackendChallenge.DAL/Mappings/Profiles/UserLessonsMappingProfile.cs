using AutoMapper;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Mappings.Profiles
{

    public class UserLessonsMappingProfile : Profile
    {
        public UserLessonsMappingProfile()
        {
            CreateMap<UserLessonsCreateModel, UserLessons>()
                .ForMember(dest => dest.Lesson, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UserLessonsModel, UserLessons>()
               .ForMember(dest => dest.User, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ReverseMap();


            CreateMap<UserLessonsCreateModel, UserLessonsModel>()
               .ForMember(dest => dest.Lesson, opt => opt.Ignore())
               .ForMember(dest => dest.User, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}

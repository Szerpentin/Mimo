using AutoMapper;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Mappings.Profiles
{
    public class ChapterMappingProfile : Profile
    {
        public ChapterMappingProfile()
        {
            CreateMap<ChapterModel, Chapters>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using MimoBackendChallenge.DAL.Mappings.Profiles;

namespace MimoBackendChallenge.DAL.Mappings
{
    public class ModelMapper
    {
        public IMapper Instance { get; }

        public ModelMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LessonMappingProfile>();
                cfg.AddProfile<UserLessonsMappingProfile>();
                cfg.AddProfile<AchievementMappingProfile>();
                cfg.AddProfile<ObjectiveMappingProfile>();
                cfg.AddProfile<CourseMappingProfile>();
                cfg.AddProfile<ChapterMappingProfile>();
                cfg.AddProfile<UserMappingProfile>();
            });

            config.AssertConfigurationIsValid();

            Instance = config.CreateMapper();
        }
    }
}

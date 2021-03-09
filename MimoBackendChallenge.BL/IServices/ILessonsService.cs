using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.BL.IServices
{
    public interface ILessonsService : ISimpleDALService<LessonModel, Lessons>
    {
    }
}

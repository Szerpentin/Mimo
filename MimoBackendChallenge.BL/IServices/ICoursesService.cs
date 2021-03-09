using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.BL.IServices
{
    public interface ICoursesService : ISimpleDALService<CourseModel, Courses>
    {
    }
}

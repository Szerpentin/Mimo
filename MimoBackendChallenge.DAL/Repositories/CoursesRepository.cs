using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Repositories
{
    public class CoursesRepository : Repository<Courses>, ICoursesRepository
    {
        public CoursesRepository(MimoContext context):base(context)
        {

        }
    }
}

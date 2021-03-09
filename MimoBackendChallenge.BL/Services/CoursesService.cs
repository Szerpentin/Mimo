using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.BL.Services
{
    public class CoursesService : SimpleDALService<CourseModel, Courses>, ICoursesService
    {
        public CoursesService(IRepository<Courses> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}

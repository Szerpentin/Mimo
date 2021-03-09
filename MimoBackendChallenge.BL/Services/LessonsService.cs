using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.Services
{
    public class LessonsService : SimpleDALService<LessonModel,Lessons>, ILessonsService
    {
        public LessonsService(IRepository<Lessons> repository, IMapper mapper) : base(repository, mapper)
        {
           
        }
    }
}

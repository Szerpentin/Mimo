using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.Services
{
    public class UserLessonsService : SimpleDALService<UserLessonsModel, UserLessons>, IUserLessonsService
    {
        private readonly IUserLessonsRepository repository;
        private readonly IMapper mapper;
        public UserLessonsService(IUserLessonsRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<UserLessonsModel>> ByUserId(int userId)
        {
            return (await repository.ByUserId(userId)).Select(s => mapper.Map<UserLessonsModel>(s)).ToList();
        }
    }

}

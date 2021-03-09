using MimoBackendChallenge.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.DAL.IRepositories
{
    public interface IUserLessonsRepository : IRepository<UserLessons>
    {
        Task<List<UserLessons>> ByUserId(int userId);
    }
}

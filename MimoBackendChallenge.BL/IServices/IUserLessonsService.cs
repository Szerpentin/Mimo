using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.IServices
{
    public interface IUserLessonsService : ISimpleDALService<UserLessonsModel, UserLessons>
    {
        Task<List<UserLessonsModel>> ByUserId(int userId);
    }
}

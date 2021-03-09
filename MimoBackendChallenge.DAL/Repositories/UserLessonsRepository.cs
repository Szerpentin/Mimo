using Microsoft.EntityFrameworkCore;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database;
using MimoBackendChallenge.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimoBackendChallenge.DAL.Repositories
{
    public class UserLessonsRepository : Repository<UserLessons>, IUserLessonsRepository
    {
        public UserLessonsRepository(MimoContext context) : base(context)
        {

        }
        public async Task<List<UserLessons>> ByUserId(int userId)
        {
            return await _context.UserLessons.Where(w => w.UserId == userId).ToListAsync();
        }
    }
}

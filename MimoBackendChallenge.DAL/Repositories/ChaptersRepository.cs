using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.DAL.Repositories
{
    public class ChaptersRepository : Repository<Chapters>, IChaptersRepository
    {
        public ChaptersRepository(MimoContext context):base(context)
        {

        }
    }
}

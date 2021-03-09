using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database;
using MimoBackendChallenge.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimoBackendChallenge.DAL.Repositories
{
    public class LessonsRepository : Repository<Lessons>, ILessonsRepository
    {
        public LessonsRepository(MimoContext context) : base(context)
        {

        }
    }
}

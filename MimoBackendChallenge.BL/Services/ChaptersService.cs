using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.BL.Services
{
    public class ChaptersService : SimpleDALService<ChapterModel, Chapters>, IChaptersService
    {
        public ChaptersService(IRepository<Chapters> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}

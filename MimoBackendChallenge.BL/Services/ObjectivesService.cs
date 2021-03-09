using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database.Entities;

namespace MimoBackendChallenge.BL.Services
{
    public class ObjectivesService : SimpleDALService<ObjectiveModel, Objectives>, IObjectivesService
    {
        public ObjectivesService(IRepository<Objectives> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
